(function(app) { // app := global object in gl. namespace (IIFE)
    
  // creating a visual component 'AppComponent'
  app.AppComponent =
    ng.core.Component({ // ng.core.Component := Angular component
      selector: 'my-app', // CSS selector for a host HTML element named my-app
      template: '<h1>My First Angular 2 App</h1>'
    })
    .Class({ // implement behaviour for view (properties & methods)
      constructor: function() {}
    });
    
})(window.app || (window.app = {}));
