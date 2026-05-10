//FINAL


// Chân kết nối cảm biến siêu âm
const int trig = 10;
const int echo = 11;

String lcdMessage = "";
unsigned long messageStartTime = 0;
bool showMessage = false;

// Biến đo và hiệu chỉnh
float distance = 0.0;
float calib = 0.0;

// Hai điểm hiệu chuẩn
float calib1 = 0.0, calib2 = 0.0;
float dist1 = 0.0, dist2 = 0.0;

bool hasCalib1 = false;
bool hasCalib2 = false;

float a = 1.0, b = 0.0;

// LCD I2C
#include <Wire.h>
#include <LiquidCrystal_I2C.h>
LiquidCrystal_I2C lcd(0x27, 16, 2);

void setup() {
  Serial.begin(115200);
  pinMode(trig, OUTPUT);
  pinMode(echo, INPUT);

  lcd.init();
  lcd.backlight();
  lcd.setCursor(0, 0);
  lcd.print("DISTANCE MEASURE");
}

void loop() {
  // Đọc dữ liệu Serial
  if (Serial.available() > 0) {
    String input = Serial.readStringUntil('\n');
    input.trim();

    if (input.startsWith("c1=")) {
      calib1 = input.substring(3).toFloat();
      delay(1000);  // đợi vật ổn định
      dist1 = measureAverageDistance(10);
      hasCalib1 = true;
      Serial.println("SET_C1_DONE");
      showLCDMessage("Saved C1");
    }

    if (input.startsWith("c2=")) {
      calib2 = input.substring(3).toFloat();
      delay(1000);  // đợi vật ổn định
      dist2 = measureAverageDistance(10);
      hasCalib2 = true;
      Serial.println("SET_C2_DONE");
      showLCDMessage("Saved C2");
    }

    // Giải hệ phương trình sau khi có đủ 2 điểm
    if (hasCalib1 && hasCalib2 && (dist2 != dist1)) {
      a = (calib2 - calib1) / (dist2 - dist1);
      b = calib1 - a * dist1;
      Serial.println("CALIB_DONE");
      showLCDMessage("Calib OK");
    }

    while (Serial.available()) Serial.read(); // xóa buffer
  }

  // Đo khoảng cách và hiệu chỉnh
distance = measureAverageDistance(5);

  if (hasCalib1 && hasCalib2) {
    calib = a * distance + b;
  } else {
    calib = distance;
  }

  if (calib < 0) calib = 0;

  // Ghi ra Serial
  Serial.print("D = ");
  Serial.print(distance, 2);
  Serial.print(" | C = ");
  Serial.print(calib, 2);
  Serial.print(" | a = ");
  Serial.print(a, 4);
  Serial.print(" | b = ");
  Serial.println(b, 4);

  // Hiển thị LCD
  // Nếu đang hiển thị message
  
lcd.setCursor(0, 0);
lcd.print("DISTANCE MEASURE");
  if (showMessage) {
  if (millis() - messageStartTime < 2000) {
  } else {
    showMessage = false;
    lcd.clear();
  }
}
if (!showMessage) {
  lcd.setCursor(2, 1);
  lcd.print("Output:");

  lcd.setCursor(11, 1);
  if (calib >= 0 && calib <= 999) {
    lcd.print("     ");
    lcd.setCursor(11, 1);
    lcd.print(String(calib, 1));
  } else {
    lcd.print("XX.X");
  }
}

  delay(100);
}

void showLCDMessage(String msg) {
  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print(msg);

  lcdMessage = msg;
  messageStartTime = millis();
  showMessage = true;
}

float measureAverageDistance(int n) {
  float sum = 0;
  int count = 0;

  for (int i = 0; i < n; i++) {
    float d = measureSingleDistance();

    if (d < 500) { // loại giá trị lỗi
      sum += d;
      count++;
    }

    delay(200); // nghỉ giữa các lần đo
  }

  if (count == 0) return 9999.0;

  return sum / count;
}

// Hàm đo khoảng cách 1 lần
float measureSingleDistance() {
  digitalWrite(trig, LOW);
  delayMicroseconds(2);
  digitalWrite(trig, HIGH);
  delayMicroseconds(10);
  digitalWrite(trig, LOW);

  float t = pulseIn(echo, HIGH, 30000);
  if (t > 0) {
    float d = t / 2.0 * 0.0343;
    return d;
  }
  return 9999.0; // lỗi
}
