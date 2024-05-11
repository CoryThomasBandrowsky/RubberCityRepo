export class HelpRequestModel {
  id: number;
  userID: number;
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string;
  postalCode: string;
  dateSubmitted: Date;
  messageBody: string;

  constructor(
    id: number,
    userID: number,
    firstName: string,
    lastName: string,
    email: string,
    phoneNumber: string,
    postalCode: string,
    dateSubmitted: Date,
    messageBody: string,
  ) {
    this.id = id;
    this.userID = userID;
    this.firstName = firstName;
    this.lastName = lastName;
    this.email = email;
    this.phoneNumber = phoneNumber;
    this.postalCode = postalCode;
    this.dateSubmitted = dateSubmitted;
    this.messageBody = messageBody;
  }
}
