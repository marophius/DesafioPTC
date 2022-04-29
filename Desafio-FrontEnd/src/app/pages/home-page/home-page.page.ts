import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.page.html',
  styleUrls: ['./home-page.page.scss'],
  animations: [
    trigger('flyInOut', [
      state('in', style({ opacity:1,transform: 'translateX(0)' })),
      transition('void => *', [
        style({ opacity:0,transform: 'translateX(-200%)' }),
        animate(2000)
      ]),
      transition('* => void', [
        animate(2000, style({ opacity:0,transform: 'translateX(-200%)' }))
      ])
    ]),
    trigger('flyInOut1', [
      state('in', style({ opacity:1,transform: 'translateX(0)' })),
      transition('void => *', [
        style({ opacity:0,transform: 'translateX(-200%)' }),
        animate(1500)
      ]),
      transition('* => void', [
        animate(1500, style({ opacity:0,transform: 'translateX(-200%)' }))
      ])
    ]),
    trigger('flyInOut2', [
      state('in', style({ opacity:1,transform: 'translateX(0)' })),
      transition('void => *', [
        style({ opacity:0,transform: 'translateX(-200%)' }),
        animate(500)
      ]),
      transition('* => void', [
        animate(500, style({ opacity:0,transform: 'translateX(-200%)' }))
      ])
    ])
  ]
})
export class HomePagePage implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
