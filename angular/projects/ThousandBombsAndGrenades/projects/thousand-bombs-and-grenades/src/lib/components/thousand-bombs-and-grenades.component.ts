import { Component, OnInit } from '@angular/core';

import { ThousandBombsAndGrenadesService } from '../services/thousand-bombs-and-grenades.service';

@Component({
  selector: 'lib-thousand-bombs-and-grenades',
  template: ` <p>thousand-bombs-and-grenades works!</p> `,
  styles: [],
})
export class ThousandBombsAndGrenadesComponent implements OnInit {
  constructor(private service: ThousandBombsAndGrenadesService) {}

  ngOnInit(): void {
    this.service.sample().subscribe((sample) => {
        console.log("Sample value: " + sample.value)
    });
  }
}
