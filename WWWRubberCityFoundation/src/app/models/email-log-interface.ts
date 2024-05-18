export interface EmailLog {
    id: number;
    toAddress: string;
    subject: string;
    body: string;
    sentAt: Date;
}
