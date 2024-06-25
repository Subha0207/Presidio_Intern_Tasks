/* JavaScript is indeed a prototype-based language, meaning that objects inherit directly from other objects.
Unlike class-based languages like Java or C++, where objects inherit from classes,
 JavaScript uses prototypes to share properties and methods between objects.*/


 //Creating an Object with a Prototype

 let person = {
    firstName: 'John',
    lastName: 'Doe',
    greet: function() {
        console.log(`Hello, my name is ${this.firstName} ${this.lastName}`);
    }
};

//Creating an Object that Inherits from the Prototype
let student = Object.create(person);
student.firstName = 'Jane';
student.lastName = 'Smith';
student.study = function() {
    console.log(`${this.firstName} is studying`);
};
//The student object is created using Object.create(person), which sets person as the prototype of student. 
//This means student inherits properties and methods from person.

student.greet(); //Inherits from person
student.study(); //Its own method

//When student.greet() is called, JavaScript first looks for the greet method on the student object. 
//If it doesn't find it there, it looks up the prototype chain and finds it on the person object.
