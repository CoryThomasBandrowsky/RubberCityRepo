export class Donation {
  id: number;
  donorName: string;
  email: string;
  amount: number;
  donationDate: Date;
  PaymentId: string;

  constructor(
    id: number,
    donorName: string,
    email: string,
    amount: number,
    donationDate: Date,
    PaymentId: string
  ) {
    this.id = id;
    this.donorName = donorName;
    this.email = email;
    this.amount = amount;
    this.donationDate = donationDate;
    this.PaymentId = PaymentId;
  }
}
