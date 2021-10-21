const path = require('path');

// This plugin will extract CSS into separate files
const MiniCssExtractPlugin = require('mini-css-extract-plugin');

// This plugin removes empty generated scripts from Sass input.
const RemoveEmptyScriptsPlugin = require('webpack-remove-empty-scripts');

// input file: src/scss/style.scss
// output file: wwwroot/styles/style.css
module.exports = {
  entry: {
    [`wwwroot/scripts/script`]: './src/main',
    [`wwwroot/styles/style`]: './src/scss/style',
  },
  mode: 'development',
  output: {
    path: __dirname, // An output dir must be an absolute path.
    filename: '[name].js',
  },
  resolve: {
    extensions: ['.ts', '.tsx', '.js', '.jsx', '.scss', '.css']

  },
  module: {
    rules: [
      {
        test: /\.(ts|js)x?$/,
        use: [
          'babel-loader',
        ],
        exclude: /node_modules/
      },
      {
        test: /\.scss$/,
        use: [
          // Extract to CSS file
          MiniCssExtractPlugin.loader,
          // Translates CSS to CommonJS and ignore solving URL of images
          'css-loader?url=false',
          // Compiles Sass to CSS
          'sass-loader',
        ],
        exclude: /node_modules/,
      },
    ]// End rules
  },
  plugins: [
    new RemoveEmptyScriptsPlugin({ verbose: true }),
    new MiniCssExtractPlugin({
      // Configure the output of CSS.
      // It is relative to output dir. Only relative path works, absolute path does not work.
      filename: '[name].css',
    }),
  ],
};
