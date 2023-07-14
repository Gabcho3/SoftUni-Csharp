function createSchoolRegisterForGrades(input) {
  const passedStudents = input.reduce((acc, curr) => {
    const [nameData, gradeData, scoreData] = curr.split(", ");
    const name = nameData.split(": ")[1];
    const grade = Number(gradeData.split(": ")[1]) + 1;
    const score = Number(scoreData.split(": ")[1]);
    const student = { name, grade, score };

    if (student.score >= 3.0) {
      acc.push(student);
    }
    return acc;
  }, []);
  passedStudents.sort((a, b) => a.grade - b.grade);

  let allGrades = new Set();
  passedStudents.forEach(({ grade }) => {
    allGrades.add(grade);
  });

  crateNeededListsInGrade(passedStudents, allGrades);
}
function crateNeededListsInGrade(passedStudents, allGrades) {
  for (const grade of allGrades) {
    const currGradeList = passedStudents.reduce((acc, curr) => {
      if (curr.grade === grade) {
        acc.push(curr);
      }
      return acc;
    }, []);

    const nameList = currGradeList.reduce((acc, curr) => {
      acc.push(curr.name);
      return acc;
    }, []);

    const averageScore =
      currGradeList.reduce((acc, curr) => {
        acc += curr.score;
        return acc;
      }, 0) / nameList.length;

    printInfoAboutGrade(grade, nameList, averageScore);
  }
}
function printInfoAboutGrade(grade, nameList, averageScore) {
  console.log(grade + " Grade");
  console.log(`List of students: ${nameList.join(", ")}`);
  console.log(
    `Average annual score from last year: ${averageScore.toFixed(2)}`
  );
  console.log();
}
createSchoolRegisterForGrades([
  "Student name: Mark, Grade: 8, Graduated with an average score: 4.75",
  "Student name: Ethan, Grade: 9, Graduated with an average score: 5.66",
  "Student name: George, Grade: 8, Graduated with an average score: 2.83",
  "Student name: Steven, Grade: 10, Graduated with an average score: 4.20",
  "Student name: Joey, Grade: 9, Graduated with an average score: 4.90",
  "Student name: Angus, Grade: 11, Graduated with an average score: 2.90",
  "Student name: Bob, Grade: 11, Graduated with an average score: 5.15",
  "Student name: Daryl, Grade: 8, Graduated with an average score: 5.95",
  "Student name: Bill, Grade: 9, Graduated with an average score: 6.00",
  "Student name: Philip, Grade: 10, Graduated with an average score: 5.05",
  "Student name: Peter, Grade: 11, Graduated with an average score: 4.88",
  "Student name: Gavin, Grade: 10, Graduated with an average score: 4.00",
]);
