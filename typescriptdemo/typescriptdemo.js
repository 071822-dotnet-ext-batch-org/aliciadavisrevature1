import { MyClass } from './otherfile.js';
console.log('Hello, World');
var myClass1 = new MyClass('Richard the LionHeart is coming', function (a) {
    return "This ".concat(a, " is better than our kingdoms.");
});
console.log(myClass1.name, myClass1.sound('pair of warthogs'));
