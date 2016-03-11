(function(app) {
  document.addEventListener('DOMContentLoaded', function() {
    ng.platform.browser.bootstrap(app.AppComponent); // import component
  });
})(window.app || (window.app = {}));