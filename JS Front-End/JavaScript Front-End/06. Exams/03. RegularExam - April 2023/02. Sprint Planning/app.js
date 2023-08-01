window.addEventListener("load", solve);

function solve() {
  const tasks = [];
  let totalTasks = 0;
  let totalPoints = 0;

  const labelIcons = {
    feature: `&#8865`,
    "low-priority": "&#9737",
    "high-priority": "&#9888",
  };

  document.getElementById("create-task-btn").addEventListener("click", addTask);

  function addTask() {
    const task = {
      label: document.getElementById("label").value,
      title: document.getElementById("title").value,
      description: document.querySelector(".form-control textarea").value,
      points: Number(document.getElementById("points").value),
      assignee: document.getElementById("assignee").value,
    };
    document.getElementById(
      "total-sprint-points"
    ).textContent = `Total Points ${(totalPoints += task.points)}pts`;
    fillOutInputs();

    if (!Object.values(task).includes("")) {
      tasks.push(task);

      const article = document.createElement("article");
      article.id = `task-${++totalTasks}`;
      article.classList.add("task-card");

      for (const [key, value] of Object.entries(task)) {
        let element;
        if (key === "label") {
          let additionalClass = value.toLowerCase().split(" ").join("-");
          additionalClass = additionalClass.replace("-bug", "");

          element = createElement(
            "div",
            ["task-card-label", additionalClass],
            value + " " + labelIcons[additionalClass]
          );
        } else if (key === "title") {
          element = createElement("h3", ["task-card-title"], value);
        } else if (key === "description") {
          element = createElement("p", ["task-card-description"], value);
        } else if (key === "points") {
          element = createElement(
            "div",
            ["task-card-points"],
            `Estimated at ${value} pts`
          );
        } else if (key === "assignee") {
          element = createElement(
            "p",
            ["task-card-assignee"],
            `Assigned to: ${value}`
          );
        }
        article.appendChild(element);
      }
      article.appendChild(
        createElement("div", ["task-card-actions"], "<button>Delete</button>")
      );

      document.getElementById("tasks-section").appendChild(article);
      attachDeleteEvent();
    }
  }

  function fillOutInputs() {
    Array.from(document.querySelectorAll("#create-task-form input")).forEach(
      (input) => {
        if (input.type != "button") {
          input.value = "";
          input.disabled = false;
        }
      }
    );
    document.getElementById("description").value = "";
    document.getElementById("description").disabled = false;
    document.getElementById("label").disabled = false;
    document.getElementById("label").value = "";
  }

  function fillInInputs(task) {
    Array.from(document.querySelectorAll("#create-task-form input")).forEach(
      (input) => {
        if (input.type != "button") {
          input.value = task[input.id];
          input.disabled = true;
        }
      }
    );
    document.getElementById("description").value = task["description"];
    document.getElementById("description").disabled = true;
    document.getElementById("label").disabled = true;
    document.getElementById("label").value = task["label"];
  }

  function createElement(type, classes, innerHTML) {
    const element = document.createElement(type);
    classes.forEach((elementClass) => element.classList.add(elementClass));
    element.innerHTML = innerHTML;

    return element;
  }

  function attachDeleteEvent() {
    Array.from(document.querySelectorAll(".task-card-actions button")).forEach(
      (btn) => {
        btn.addEventListener("click", (e) => {
          const id = btn.parentElement.parentElement.id;
          confirmDeleteTask(id);
        });
      }
    );
  }

  function confirmDeleteTask(id) {
    const title = document.getElementById(id).querySelector("h3").textContent;

    const task = tasks.find((task) => task.title === title);
    fillInInputs(task);

    document.getElementById("task-id").value = id;
    document.getElementById("create-task-btn").disabled = true;

    const deleteButoon = document.getElementById("delete-task-btn");
    deleteButoon.disabled = false;

    deleteButoon.addEventListener("click", (e) => {
      document.getElementById(id).remove();
      tasks.splice(tasks.indexOf(task), 1);
      deleteButoon.disabled = true;

      document.getElementById("create-task-btn").disabled = false;
      document.getElementById("task-id").value = "";

      document.getElementById(
        "total-sprint-points"
      ).textContent = `Total Points ${(totalPoints -= task.points)}pts`;

      fillOutInputs();
    });
  }
}
