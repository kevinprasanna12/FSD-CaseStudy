var CourseCategory;
(function (CourseCategory) {
    CourseCategory["FrontEnd"] = "Front-End";
    CourseCategory["BackEnd"] = "Back-End";
    CourseCategory["FullStack"] = "Full-Stack";
})(CourseCategory || (CourseCategory = {}));
var Enrollment = /** @class */ (function () {
    function Enrollment(student) {
        this.student = student;
    }
    Enrollment.prototype.getCourseCategory = function () {
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
    };
    Enrollment.prototype.isEligible = function () {
        if (this.student.age < 18) {
            return false;
        }
        if (this.student.courseName === "Angular" && !this.student.knowsHTML) {
            return false;
        }
        return true;
    };
    Enrollment.prototype.displayEnrollmentSummary = function () {
        console.log("Student Name: ".concat(this.student.name));
        console.log("Age: ".concat(this.student.age));
        console.log("Course: ".concat(this.student.courseName));
        console.log("Knows HTML: ".concat(this.student.knowsHTML));
        console.log("Course Category: ".concat(this.getCourseCategory()));
        console.log("Enrollment Status: ".concat(this.isEligible() ? "Eligible" : "Not Eligible"));
        console.log("------------------------");
    };
    return Enrollment;
}());
var students = [
    { name: "Sneha", age: 20, courseName: "Angular", knowsHTML: true },
    { name: "Karan", age: 17, courseName: "Node.js", knowsHTML: false },
    { name: "Riya", age: 22, courseName: "Angular", knowsHTML: false },
    { name: "Aman", age: 25, courseName: "FullStack", knowsHTML: true }
];
for (var _i = 0, students_1 = students; _i < students_1.length; _i++) {
    var student = students_1[_i];
    var enrollment = new Enrollment(student);
    enrollment.displayEnrollmentSummary();
}
