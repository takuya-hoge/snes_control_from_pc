// Arduino pin
#define PIN_B         15
#define PIN_Y         17
#define PIN_SELECT    3
#define PIN_START     2
#define PIN_UP        5
#define PIN_DOWN      8
#define PIN_LEFT      6
#define PIN_RIGHT     7
#define PIN_A         14
#define PIN_X         18
#define PIN_L         4
#define PIN_R         16

// ON
#define BTN_B_ON      1
#define BTN_Y_ON      2
#define BTN_SELECT_ON 3
#define BTN_START_ON  4
#define BTN_UP_ON     5
#define BTN_DOWN_ON   6
#define BTN_LEFT_ON   7
#define BTN_RIGHT_ON  8
#define BTN_A_ON      9
#define BTN_X_ON      10
#define BTN_L_ON      11
#define BTN_R_ON      12

// OFF
#define BTN_B_OFF     13
#define BTN_Y_OFF     14
#define BTN_SELECT_OFF  15
#define BTN_START_OFF   16
#define BTN_UP_OFF      17
#define BTN_DOWN_OFF    18
#define BTN_LEFT_OFF    19
#define BTN_RIGHT_OFF   20
#define BTN_A_OFF       21
#define BTN_X_OFF       22
#define BTN_L_OFF       23
#define BTN_R_OFF       24

// BTN ALL OFF
#define BTN_ALL_OFF     80

// Hadoken : Max BTM is 100
// [0]:90 [1]:length [2]:BTN [3]:wait(ms) [4]:BTN [5]:wait(ms) ...
#define HADOKEN         90

void setup() {
  // put your setup code here, to run once:
  pinMode(PIN_Y, OUTPUT);
  pinMode(PIN_SELECT, OUTPUT);
  pinMode(PIN_START, OUTPUT);
  pinMode(PIN_UP, OUTPUT);
  pinMode(PIN_DOWN, OUTPUT);
  pinMode(PIN_LEFT, OUTPUT);
  pinMode(PIN_RIGHT, OUTPUT);
  pinMode(PIN_A, OUTPUT);
  pinMode(PIN_X, OUTPUT);
  pinMode(PIN_L, OUTPUT);
  pinMode(PIN_R, OUTPUT);

  bnt_off();

  Serial.begin(9600);
  Serial.print("Hello\n");
}
// global data
int tmp_read;  // only one

void loop() {
  // put your main code here, to run repeatedly:
  tmp_read = Serial.read();
  if (-1 == tmp_read) {
    // data unavailable
  } else if (HADOKEN == tmp_read) {
    hadoken();
  } else {
    btn_control(tmp_read);
  }
}

void btn_control(unsigned char data)
{
  switch (data) {
    case BTN_B_ON:
      digitalWrite(PIN_B, LOW);
      break;
    case BTN_Y_ON:
      digitalWrite(PIN_Y, LOW);
      break;
    case BTN_SELECT_ON:
      digitalWrite(PIN_SELECT, LOW);
      break;
    case BTN_START_ON:
      digitalWrite(PIN_START, LOW);
      break;
    case BTN_UP_ON:
      digitalWrite(PIN_UP, LOW);
      break;
    case BTN_DOWN_ON:
      digitalWrite(PIN_DOWN, LOW);
      break;
    case BTN_LEFT_ON:
      digitalWrite(PIN_LEFT, LOW);
      break;
    case BTN_RIGHT_ON:
      digitalWrite(PIN_RIGHT, LOW);
      break;
    case BTN_A_ON:
      digitalWrite(PIN_A, LOW);
      break;
    case BTN_X_ON:
      digitalWrite(PIN_X, LOW);
      break;
    case BTN_L_ON:
      digitalWrite(PIN_L, LOW);
      break;
    case BTN_R_ON:
      digitalWrite(PIN_R, LOW);
      break;
    case BTN_B_OFF:
      digitalWrite(PIN_B, HIGH);
      break;
    case BTN_Y_OFF:
      digitalWrite(PIN_Y, HIGH);
      break;
    case BTN_SELECT_OFF:
      digitalWrite(PIN_SELECT, HIGH);
      break;
    case BTN_START_OFF:
      digitalWrite(PIN_START, HIGH);
      break;
    case BTN_UP_OFF:
      digitalWrite(PIN_UP, HIGH);
      break;
    case BTN_DOWN_OFF:
      digitalWrite(PIN_DOWN, HIGH);
      break;
    case BTN_LEFT_OFF:
      digitalWrite(PIN_LEFT, HIGH);
      break;
    case BTN_RIGHT_OFF:
      digitalWrite(PIN_RIGHT, HIGH);
      break;
    case BTN_A_OFF:
      digitalWrite(PIN_A, HIGH);
      break;
    case BTN_X_OFF:
      digitalWrite(PIN_X, HIGH);
      break;
    case BTN_L_OFF:
      digitalWrite(PIN_L, HIGH);
      break;
    case BTN_R_OFF:
      digitalWrite(PIN_R, HIGH);
      break;
    case BTN_ALL_OFF:
            bnt_off();
      break;
    default:
      break;
  }
}

void hadoken()
{
  unsigned char length;
  unsigned char data[255];
  unsigned char seek = 0;

  // get length
  while (1)
  {
    tmp_read = Serial.read();
    if (-1 != tmp_read)
    {
      length = tmp_read;
      break;
    }
  }

  // get data
  while (1)
  {
    tmp_read = Serial.read();
    if (-1 != tmp_read)
    {
      data[seek] = tmp_read;
      seek++;
      if (seek == length) {
        break;
      }
    }
  }

  // put BTN
  for (seek = 0;seek <= length; seek += 2) {
    btn_control(data[seek]);
    delay(data[seek + 1]);
  }

  // send end signal;
  Serial.write('E');
}

void bnt_off(){
  digitalWrite(PIN_Y, HIGH);
  digitalWrite(PIN_SELECT, HIGH);
  digitalWrite(PIN_START, HIGH);
  digitalWrite(PIN_UP, HIGH);
  digitalWrite(PIN_DOWN, HIGH);
  digitalWrite(PIN_LEFT, HIGH);
  digitalWrite(PIN_RIGHT, HIGH);
  digitalWrite(PIN_A, HIGH);
  digitalWrite(PIN_B, HIGH);
  digitalWrite(PIN_X, HIGH);
  digitalWrite(PIN_L, HIGH);
  digitalWrite(PIN_R, HIGH);
}

void test()
{
  digitalWrite(2, HIGH);
  delay(10);
  digitalWrite(2, LOW);
  delay(10);

  digitalWrite(PIN_A, HIGH);
  delay(50);
  digitalWrite(PIN_A, LOW);

  digitalWrite(PIN_LEFT, LOW);
  delay(400);
  digitalWrite(PIN_LEFT, HIGH);
  delay(400);
  digitalWrite(PIN_RIGHT, LOW);
  delay(400);
  digitalWrite(PIN_RIGHT, HIGH);
  delay(400);
}
