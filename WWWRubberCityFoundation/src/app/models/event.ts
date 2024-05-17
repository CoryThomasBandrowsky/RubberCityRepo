export class Event {
    id: number;
    hostedByUserId: number;
    name: string;
    location: string;
    date: Date;
    description: string;
    type: number;
    isActive: boolean;
    isPublic: boolean;
    isFree: boolean;
    isDonationRequired: boolean;
  
    constructor(
      id: number,
      hostedByUserId: number,
      name: string,
      location: string,
      date: Date,
      description: string,
      type: number,
      isActive: boolean,
      isPublic: boolean,
      isFree: boolean,
      isDonationRequired: boolean
    ) {
      this.id = id;
      this.hostedByUserId = hostedByUserId;
      this.name = name;
      this.location = location;
      this.date = date;
      this.description = description;
      this.type = type;
      this.isActive = isActive;
      this.isPublic = isPublic;
      this.isFree = isFree;
      this.isDonationRequired = isDonationRequired;
    }
  }
  