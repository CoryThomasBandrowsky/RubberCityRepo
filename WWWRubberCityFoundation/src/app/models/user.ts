export class User {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  inputPassword: string;
  phoneNumber: string;
  postalCode: string;
  memberSince: Date;
  userRole: string;
  needsHelp: boolean;
  canHelp: boolean;
  isLockedOut: boolean;
  isBanned: boolean;
  isActive: boolean;

  constructor(
    id: number,
    firstName: string,
    lastName: string,
    email: string,
    inputPassword: string,
    phoneNumber: string,
    postalCode: string,
    memberSince: Date,
    userRole: string,
    needsHelp: boolean,
    canHelp: boolean,
    isLockedOut: boolean,
    isBanned: boolean,
    isActive: boolean
  ) {
    this.id = id;
    this.firstName = firstName;
    this.lastName = lastName;
    this.email = email;
    this.inputPassword = inputPassword;
    this.phoneNumber = phoneNumber;
    this.postalCode = postalCode;
    this.memberSince = memberSince;
    this.userRole = userRole;
    this.needsHelp = needsHelp;
    this.canHelp = canHelp;
    this.isLockedOut = isLockedOut;
    this.isBanned = isBanned;
    this.isActive = isActive;
  }
}
