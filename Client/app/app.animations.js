'use strict';

angular.
  module('phonecatApp').
  animation('.phone', function phoneAnimationFactory() {
    return {
      addClass: animateIn,
      removeClass: animateOut
    };

    function animateIn(element, className, done) {
      if (className !== 'selected') return;

      /*element.css({
        display: 'block',
        position: 'absolute',
        top: -500,
        left: 0
      }).animate({
        top: 0
      }, done);*/
        
      element.css({
          display: 'block',
          opacity: 1,
          position: 'absolute',
          width: 0,
          height: 0,
          top: 200,
          left: 200
      }).animate({
          width: 400,
          height: 400,
          top: 0,
          left: 0
      }, done);

      return function animateInEnd(wasCanceled) {
        if (wasCanceled) element.stop();
      };
    }

    function animateOut(element, className, done) {
      if (className !== 'selected') return;

      /*element.css({
        position: 'absolute',
        top: 0,
        left: 0
      }).animate({
        top: 500
      }, done);*/
        
      element.animate({
          opacity: 0
      }, done);

      return function animateOutEnd(wasCanceled) {
        if (wasCanceled) element.stop();
      };
    }
  });