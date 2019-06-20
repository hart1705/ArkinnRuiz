import { Directive, ElementRef, Input, AfterContentInit } from '@angular/core';

@Directive({
  selector: '[appAutofocus]'
})
export class AutofocusDirective implements AfterContentInit{
  @Input() public autoFocus: boolean;

  constructor(private el: ElementRef) { }

  ngAfterContentInit(): void {
    setTimeout(() => {

      this.el.nativeElement.focus();

    }, 500)
    
  }
}
