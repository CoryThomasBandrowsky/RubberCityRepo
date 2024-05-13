export class DashboardResult {
    UserID: number;
    FirstName: string;
    LastName: string;
    Summary: string;
    DateCreated: Date;
  
    constructor(
      UserID: number,
      FirstName: string,
      LastName: string,
      Summary: string,
      DateCreated: Date
    ) {
      this.UserID = UserID;
      this.FirstName = FirstName;
      this.LastName = LastName;
      this.Summary = Summary;
      this.DateCreated = DateCreated;
    }
  }
  