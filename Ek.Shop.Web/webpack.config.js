/*
 * Webpack (JavaScriptServices) with a few changes & updates
 * - This is to keep us inline with JSServices, and help those using that template to add things from this one
 *
 * Things updated or changed:
 * module -> rules []
 *    .ts$ test : Added 'angular2-router-loader' for lazy-loading in development
 *    added ...sharedModuleRules (for scss & font-awesome loaders)
 */

const path = require('path');
const webpack = require('webpack');
const merge = require('webpack-merge');
const AngularCompilerPlugin = require('@ngtools/webpack').AngularCompilerPlugin;
const CheckerPlugin = require('awesome-typescript-loader').CheckerPlugin;
const BundleAnalyzerPlugin = require('webpack-bundle-analyzer').BundleAnalyzerPlugin;
const UglifyJsPlugin = require('uglifyjs-webpack-plugin');
const { sharedModuleRules } = require('./webpack.additions');

module.exports = (env) => {
    // Configuration in common to both client-side and server-side bundles
    const isDevBuild = !(env && env.prod);
    const sharedConfig = {
        mode: isDevBuild ? "development" : "production",
        stats: { modules: false },
        context: __dirname,
        resolve: { extensions: [ '.js', '.ts' ] },
        output: {
            filename: '[name].js',
            publicPath: 'dist/' // Webpack dev middleware, if enabled, handles requests for this URL prefix
        },
        module: {
            rules: [
                { test: /\.ts$/, use: isDevBuild ? ['awesome-typescript-loader?silent=true', 'angular2-template-loader', 'angular2-router-loader'] : '@ngtools/webpack' },
                { test: /\.html$/, use: 'html-loader?minimize=false' },
                { test: /\.css$/, use: ['to-string-loader', isDevBuild ? 'css-loader' : 'css-loader?minimize'] },
                { test: /\.scss$/, loaders: ['to-string-loader', isDevBuild ? 'css-loader' : 'css-loader?minimize', 'sass-loader'] },
                { test: /\.(png|jpg|jpeg|gif|svg)$/, use: 'url-loader?limit=25000' },
                ...sharedModuleRules
            ]
        },
        plugins: [new CheckerPlugin()]
    };

    // Configuration for client-side bundle suitable for running in browsers
    const clientSideBundleOutputDir = './wwwroot/dist';
    const clientBrowserBundleConfig = merge(sharedConfig, {
        entry: { 'client-app-browser': './App/client-boot.browser.ts' },
        output: { path: path.join(__dirname, clientSideBundleOutputDir) },
        plugins: [
            new webpack.DllReferencePlugin({
                context: __dirname,
                manifest: require('./wwwroot/dist/vendor-manifest.json')
            })
        ].concat(isDevBuild ? [
            // Plugins that apply in development builds only
            new webpack.SourceMapDevToolPlugin({
                filename: '[file].map', // Remove this line if you prefer inline source maps
                moduleFilenameTemplate: path.relative(clientSideBundleOutputDir, '[resourcePath]') // Point sourcemap entries to the original file locations on disk
            })
        ] : [
                // Plugins that apply in production builds only
                new AngularCompilerPlugin({
                    mainPath: path.join(__dirname, 'App/client-boot.browser.ts'),
                    tsConfigPath: './tsconfig.json',
                    entryModule: path.join(__dirname, 'App/client/client.module.browser#ClientModule'),
                    exclude: ['./**/*.server.ts']
                })
            ]),
        devtool: isDevBuild ? 'cheap-eval-source-map' : false,
        node: {
            fs: "empty"
        },
        optimization: {
            minimizer: [].concat(isDevBuild ? [] : [
                // we specify a custom UglifyJsPlugin here to get source maps in production
                new UglifyJsPlugin({
                    cache: true,
                    parallel: true,
                    uglifyOptions: {
                        compress: false,
                        ecma: 6,
                        mangle: true
                    },
                    sourceMap: true
                })
            ])
        }
    });

    const adminBrowserBundleConfig = merge(sharedConfig, {
        entry: { 'admin-app-browser': './App/admin-boot.browser.ts' },
        output: { path: path.join(__dirname, clientSideBundleOutputDir) },
        plugins: [
            new webpack.DllReferencePlugin({
                context: __dirname,
                manifest: require('./wwwroot/dist/vendor-manifest.json')
            })
        ].concat(isDevBuild ? [
            // Plugins that apply in development builds only
            new webpack.SourceMapDevToolPlugin({
                filename: '[file].map', // Remove this line if you prefer inline source maps
                moduleFilenameTemplate: path.relative(clientSideBundleOutputDir, '[resourcePath]') // Point sourcemap entries to the original file locations on disk
            })
        ] : [
                // Plugins that apply in production builds only
                new AngularCompilerPlugin({
                    mainPath: path.join(__dirname, 'App/admin-boot.browser.ts'),
                    tsConfigPath: './tsconfig.json',
                    entryModule: path.join(__dirname, 'App/admin/admin.module.browser#AdminModule'),
                    exclude: ['./**/*.server.ts']
                })
            ]),
        devtool: isDevBuild ? 'cheap-eval-source-map' : false,
        node: {
            fs: "empty"
        },
        optimization: {
            minimizer: [].concat(isDevBuild ? [] : [
                // we specify a custom UglifyJsPlugin here to get source maps in production
                new UglifyJsPlugin({
                    cache: true,
                    parallel: true,
                    uglifyOptions: {
                        compress: false,
                        ecma: 6,
                        mangle: true
                    },
                    sourceMap: true
                })
            ])
        }
    });

    // Configuration for server-side (prerendering) bundle suitable for running in Node
    const clientServerBundleConfig = merge(sharedConfig, {
        //resolve: { mainFields: ['main'] },
        entry: { 'client-app-server': isDevBuild ? './App/client-boot.server.ts' : './App/client-boot.server.production.ts'},
        plugins: [
            new webpack.DllReferencePlugin({
                context: __dirname,
                manifest: require('./App/dist/vendor-manifest.json'),
                sourceType: 'commonjs2',
                name: './vendor'
            })
        ].concat(isDevBuild ? [
            new webpack.ContextReplacementPlugin(
                // fixes WARNING Critical dependency: the request of a dependency is an expression
                /(.+)?angular(\\|\/)core(.+)?/,
                path.join(__dirname, 'src'), // location of your src
                {} // a map of your routes
            ),
            new webpack.ContextReplacementPlugin(
                // fixes WARNING Critical dependency: the request of a dependency is an expression
                /(.+)?express(\\|\/)(.+)?/,
                path.join(__dirname, 'src'),
                {}
            )
        ] : [
                new webpack.optimize.UglifyJsPlugin({
                    mangle: false,
                    compress: false,
                    output: {
                        ascii_only: true
                    }
                }),
                // Plugins that apply in production builds only
                new AngularCompilerPlugin({
                    mainPath: path.join(__dirname, 'App/client-boot.server.production.ts'),
                    tsConfigPath: './tsconfig.json',
                    entryModule: path.join(__dirname, 'App/client/client.module.server#ClientModule'),
                    exclude: ['./**/*.browser.ts']
            })
        ]),
        output: {
            libraryTarget: 'commonjs',
            path: path.join(__dirname, './App/dist')
        },
        target: 'node',
        devtool: isDevBuild ? 'cheap-eval-source-map' : false,
        optimization: {
            minimizer: [].concat(isDevBuild ? [] : [
                // we specify a custom UglifyJsPlugin here to get source maps in production
                new UglifyJsPlugin({
                    cache: true,
                    parallel: true,
                    uglifyOptions: {
                        compress: false,
                        ecma: 6,
                        mangle: true
                    },
                    sourceMap: true
                })
            ])
        }
    });

    return [clientBrowserBundleConfig, adminBrowserBundleConfig, clientServerBundleConfig];
};
