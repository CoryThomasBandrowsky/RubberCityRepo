export class DashboardResult {
    userID: number;
    firstName: string;
    lastName: string;
    summary: string;
    dateCreated: Date;
  
    constructor(
      userID: number,
      firstName: string,
      lastName: string,
      summary: string,
      dateCreated: Date
    ) {
      this.userID = userID;
      this.firstName = firstName;
      this.lastName = lastName;
      this.summary = summary;
      this.dateCreated = dateCreated;
    }
  }
  