enum CourseCategory {
    FrontEnd = "Front-End",
    BackEnd = "Back-End",
    FullStack = "Full-Stack"
}

interface Student {
    name: string;
    age: number;
    courseName: string;
    knowsHTML: boolean;
}

class Enrollment {
    private student: Student;

    constructor(student: Student) {
        this.student = student;
    }

    private getCourseCategory(): CourseCategory {
        switch (this.student.courseName) {
            case "Angular":
                return CourseCategory.FrontEnd;
            case "Node.js":
                return CourseCategory.BackEnd;
            case "FullStack":
                return CourseCategory.FullStack;
            default:
                throw new Error("Unknown course name.");
        }
    }

    private isEligible(): boolean {
        if (this.student.age < 18) {
            return false;
        }
        if (this.student.courseName === "Angular" && !this.student.knowsHTML) {
            return false;
        }
        return true;
    }

    displayEnrollmentSummary(): void {
        console.log(`Student Name: ${this.student.name}`);
        console.log(`Age: ${this.student.age}`);
        console.log(`Course: ${this.student.courseName}`);
        console.log(`Knows HTML: ${this.student.knowsHTML}`);
        console.log(`Course Category: ${this.getCourseCategory()}`);
        console.log(`Enrollment Status: ${this.isEligible() ? "Eligible" : "Not Eligible"}`);
        console.log(`------------------------`);
    }
}

const students: Student[] = [
    { name: "Sneha", age: 20, courseName: "Angular", knowsHTML: true },
    { name: "Karan", age: 17, courseName: "Node.js", knowsHTML: false },
    { name: "Riya", age: 22, courseName: "Angular", knowsHTML: false },
    { name: "Aman", age: 25, courseName: "FullStack", knowsHTML: true }
];

for (const student of students) {
    const enrollment = new Enrollment(student);
    enrollment.displayEnrollmentSummary();
}
