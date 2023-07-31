function solve(input) {
  class Task {
    constructor(id, title, status, points) {
      this.id = id;
      this.title = title;
      this.status = status;
      this.points = Number(points);
    }
  }

  class Assignee {
    constructor(name) {
      this.name = name;
      this.tasks = [];
    }
    addTask(task) {
      this.tasks.push(task);
    }
  }

  const assigneesNum = Number(input.shift());
  const assignees = [];
  addAssignees(assigneesNum);
  takeCommands();
  printOutput();

  function addAssignees(assigneesNum) {
    for (let i = 0; i < assigneesNum; i++) {
      const [assigneeName, taskId, title, status, estimatedPoints] = input
        .shift()
        .split(":");

      const task = new Task(taskId, title, status, estimatedPoints);

      let assignee = assignees.find(
        (assignee) => assignee.name === assigneeName
      );

      if (!assignee) {
        assignee = new Assignee(assigneeName);
        assignee.addTask(task);
        assignees.push(assignee);
      } else {
        assignee.addTask(task);
      }
    }
  }

  function takeCommands() {
    input.forEach((element) => {
      const [command, assigneeName, ...elements] = element.split(":");

      const assignee = findAssignee(assigneeName);

      if (assignee) {
        switch (command) {
          case "Add New":
            const [taskId, title, status, points] = elements;
            const task = new Task(taskId, title, status, points);
            assignee.addTask(task);
            break;

          case "Change Status":
            const [_id, _title] = elements;
            changeTaskStatus(assignee, _id, _title);
            break;

          case "Remove Task":
            const [taskIndex] = elements;
            removeTask(assignee, taskIndex);
            break;
        }
      }
    });
  }

  function printOutput() {
    const toDoPoints = returnPoints("ToDo");
    const inProgressPoints = returnPoints("In Progress");
    const codeReviewPoints = returnPoints("Code Review");
    const donePoints = returnPoints("Done");

    console.log(`ToDo: ${toDoPoints}pts`);
    console.log(`In Progress: ${inProgressPoints}pts`);
    console.log(`Code Review: ${codeReviewPoints}pts`);
    console.log(`Done Points: ${donePoints}pts`);

    const isSuccessful =
      donePoints >= toDoPoints + inProgressPoints + codeReviewPoints;

    if (isSuccessful) {
      console.log("Sprint was successful!");
    } else {
      console.log("Sprint was unsuccessful...");
    }
  }

  function returnPoints(status) {
    const arrayOfTasks = [];

    assignees.filter((assignee) => {
      assignee.tasks.forEach((task) => {
        if (task.status === status) {
          arrayOfTasks.push(task);
        }
      });
    });

    return arrayOfTasks.reduce((acc, curr) => {
      return acc + curr.points;
    }, 0);
  }

  function findAssignee(assigneeName) {
    const assignee = assignees.find(
      (assignee) => assignee.name === assigneeName
    );

    if (assignee) {
      return assignee;
    } else {
      console.log(`Assignee ${assigneeName} does not exist on the board!`);
    }
  }

  function changeTaskStatus(assignee, taskId, newStatus) {
    const taskMatch = assignee.tasks.find((task) => task.id === taskId);

    if (taskMatch) {
      taskMatch.status = newStatus;
    } else {
      console.log(
        `Task with ID ${taskId} does not exist for ${assignee.name}!`
      );
    }
  }

  function removeTask(assignee, taskIndex) {
    const tasksLength = assignee.tasks.length;

    if (taskIndex < 0 || taskIndex >= tasksLength) {
      console.log(`Index is out of range!`);
    } else {
      assignee.tasks.splice(taskIndex, 1);
    }
  }
}
solve([
  "5",
  "Kiril:BOP-1209:Fix Minor Bug:ToDo:3",
  "Mariya:BOP-1210:Fix Major Bug:In Progress:3",
  "Peter:BOP-1211:POC:Code Review:5",
  "Georgi:BOP-1212:Investigation Task:Done:2",
  "Mariya:BOP-1213:New Account Page:In Progress:13",
  "Add New:Kiril:BOP-1217:Add Info Page:In Progress:5",
  "Change Status:Peter:BOP-1290:ToDo",
  "Remove Task:Mariya:1",
  "Remove Task:Joro:1",
]);
solve([
  "4",
  "Kiril:BOP-1213:Fix Typo:Done:1",
  "Peter:BOP-1214:New Products Page:In Progress:2",
  "Mariya:BOP-1215:Setup Routing:ToDo:8",
  "Georgi:BOP-1216:Add Business Card:Code Review:3",
  "Add New:Sam:BOP-1237:Testing Home Page:Done:3",
  "Change Status:Georgi:BOP-1216:Done",
  "Change Status:Will:BOP-1212:In Progress",
  "Remove Task:Georgi:3",
  "Change Status:Mariya:BOP-1215:Done",
]);
