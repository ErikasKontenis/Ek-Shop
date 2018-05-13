import 'zone.js/dist/zone-node';
import './polyfills/server.polyfills';
import { enableProdMode } from '@angular/core';
import { createServerRenderer } from 'aspnet-prerendering';

// Grab the (Node) server-specific NgModule
import { ClientModule } from './client/client.module.server';
import { ngAspnetCoreEngine, IEngineOptions, createTransferScript } from '@nguniversal/aspnetcore-engine';

enableProdMode();

export default createServerRenderer((params) => {
    
    // Platform-server provider configuration
    const setupOptions: IEngineOptions = {
        appSelector: '<client></client>',
        ngModule: ClientModule,
        request: params,
        providers: [
        
        ]
    };
    
    return ngAspnetCoreEngine(setupOptions).then(response => {
        
        // Apply transferData to response.globals
        response.globals.transferData = createTransferScript({
            someData: 'Transfer this to the client on the window.TRANSFER_CACHE {} object',
            fromDotnet: params.data.thisCameFromDotNET
        });
        
        return ({
            html: response.html, // <client></client> serialized
            globals: response.globals // all of styles/scripts/meta-tags/link-tags for aspnet to serve up
        });
    });
});
