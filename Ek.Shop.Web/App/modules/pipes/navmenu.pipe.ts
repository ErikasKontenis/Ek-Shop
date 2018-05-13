import { PipeTransform, Pipe } from '@angular/core';

@Pipe({
    name: 'navMenu'
})

export class NavMenuPipe implements PipeTransform {
    transform(items: Array<any>, id: number): Array<any> {
        return items.filter(item => item.parentId === id);
    }
}
