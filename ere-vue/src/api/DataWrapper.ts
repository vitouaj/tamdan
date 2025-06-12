export interface LoginWrapper {
  emailOrPhoneNumber: String;
  password: String;
  token?: String;
  deviceId?: String;
  deviceName?: String;
  deviceType?: String;
  deviceOs?: String;
  ipAddress?: String;
}
export interface RegisterWrapper {
  firstName: String;
  lastName: String;
  password: String;
  email: String;
  phone: String;
  role: Number;
  subject?: Number;
  levelId?: Number;
  contacts: Array<ContactWrapper>;
}

export interface ContactWrapper {
  firstName: String;
  lastName: String;
  email: String;
  phone: String;
  homeNumber: String;
  street: String;
  village: String;
  commune: String;
  district: String;
  province: String;
}

export interface User {
  name: string;
  phone: string;
  email: string;
  role: Number;
  subject: string;
  levelId: string;
  userId: string;
  studentId: string;
  createdDate: string;
  updatedDate: string;
  totalAbsence: Number;
  totalScore: Number;
  overallGrade: string;
  averageScore: Number;
  occupiedHours: Array<CourseHour>;
}

export interface Course {
  level: Number;
  maxScore: Number;
  passingRate: Number;
  courseHours: Array<CourseHour>;
}

export interface CourseHour {
  day: Number;
  time: Number;
}
