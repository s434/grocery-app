import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor() {
    this.initializeSDK();
  }

  // Pretend SDK initialization
  private initializeSDK() {
    console.log('OneSignal SDK Initialized (Mock)');
  }

  sendPromoNotification(title: string, message: string) {

    const payload = {
      headings: { en: title },
      contents: { en: message },
      included_segments: ['All']
    };

    console.log('Sending notification to OneSignal...');
    console.log(payload);

    return Promise.resolve(true);
  }
}
