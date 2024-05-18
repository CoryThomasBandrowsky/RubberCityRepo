export class LocalHelp {
    id: number;
    linkUrl: string;
    description: string;
    email: string;
    phone: string;

    constructor(id: number, linkUrl: string, description: string, email: string, phone: string) {
        this.id = id;
        this.linkUrl = linkUrl;
        this.description = description;
        this.email = email;
        this.phone = phone;
    }
}
