import './polyfills/browser.polyfills';
import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { ClientModule } from './client/client.module.browser';

// TODO fix uncommenting on prod build
enableProdMode();
const modulePromise = platformBrowserDynamic().bootstrapModule(ClientModule);

// // Enable either Hot Module Reloading or production mode
if (module['hot']) {
    module['hot'].accept();
    module['hot'].dispose(() => {
        modulePromise.then(clientModule => clientModule.destroy());
    });
} else {
    modulePromise.then(() => {
        if (navigator.hasOwnProperty('service-worker')) {
            navigator.serviceWorker.register('/ngsw-worker.js')
        }
    }).catch(err => console.log(err));
}
