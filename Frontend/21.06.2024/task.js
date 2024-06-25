
class Student {
    constructor(name, rollNumber) {
        this.name = name;
        this.rollNumber = rollNumber;
        this.marks = {
            quarterly: 0,
            halfYearly: 0,
            annual: 0
        };
    }

    // Encapsulation
    setMarks(quarterly, halfYearly, annual) {
        this.marks.quarterly = quarterly;
        this.marks.halfYearly = halfYearly;
        this.marks.annual = annual;
    }

    getMarks() {
        return this.marks;
    }

    // Polymorphism
    calculateAverageMarks() {
        let totalMarks = this.marks.quarterly + this.marks.halfYearly + this.marks.annual;
        return totalMarks / 3;
    }
}

// Inheritance: Create a subclass for JRC Student (Junior Red Cross)
class JRCStudent extends Student {
    constructor(name, rollNumber, programName) {
        super(name, rollNumber);
        this.programName = programName;
    }

    // Polymorphism: Override calculateAverageMarks for JRC student
    calculateAverageMarks() {
        // JRC students get a 5 additional marks in each term
        let totalMarks = this.marks.quarterly + this.marks.halfYearly + this.marks.annual + 15;
        let average = totalMarks / 3;


        return average;
    }
}


let student1 = new Student("John Doe", 1);
student1.setMarks(450, 475, 480);
console.log(`${student1.name}'s marks:`);
console.log(student1.getMarks());
console.log(`Average marks: ${student1.calculateAverageMarks().toFixed(2)}`);

let jrcStudent1 = new JRCStudent("Jane Smith", 2, "Junior Red Cross");
jrcStudent1.setMarks(450, 475, 480);
console.log(`${jrcStudent1.name} (${jrcStudent1.programName})'s marks:`);
console.log(jrcStudent1.getMarks());
console.log(`Average marks (with JRC bonus): ${jrcStudent1.calculateAverageMarks().toFixed(2)}`);