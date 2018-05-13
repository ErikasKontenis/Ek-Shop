import { Directive, Input, OnInit } from '@angular/core';

@Directive({
    selector: '[init]',
})
export class InitDirective implements OnInit {
    @Input() init;

    ngOnInit() {
        if (this.init) { this.init(); }
    }
}
