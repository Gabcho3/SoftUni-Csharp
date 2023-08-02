window.addEventListener("load", solve);

function solve() {
  const inputFields = {
    Title: document.getElementById("task-title"),
    Category: document.getElementById("task-category"),
    Content: document.getElementById("task-content"),
  };

  const selectors = {
    "Review List": document.getElementById("review-list"),
    "Published List": document.getElementById("published-list"),
  };

  const tasks = [];

  document.getElementById("publish-btn").addEventListener("click", publishTask);

  function publishTask() {
    const title = inputFields.Title.value;
    const category = inputFields.Category.value;
    const content = inputFields.Content.value;

    if (!title || !category || !content) {
      Object.values(inputFields).forEach((input) => (input.value = ""));
      return;
    }
    tasks.push({ title, category, content });

    const listItem = createElement("li", ["rpost"], null, null);
    const article = createElement("article", null, null, listItem);
    createElement("h4", null, inputFields["Title"].value, article);
    createElement(
      "p",
      null,
      "Category: " + inputFields["Category"].value,
      article
    );
    createElement(
      "p",
      null,
      "Content: " + inputFields["Content"].value,
      article
    );

    const editButton = createElement(
      "button",
      ["action-btn", "edit"],
      "Edit",
      listItem
    );

    const postButton = createElement(
      "button",
      ["action-btn", "post"],
      "Post",
      listItem
    );

    selectors["Review List"].appendChild(listItem);
    Object.values(inputFields).forEach((input) => (input.value = ""));

    editButton.addEventListener("click", editTask);
    postButton.addEventListener("click", postTask);
  }

  function createElement(type, classes, textContent, parentElement) {
    const element = document.createElement(type);

    if (classes && classes.length > 0) {
      element.classList.add(...classes);
    }

    if (textContent) {
      element.textContent = textContent;
    }

    if (parentElement) {
      parentElement.appendChild(element);
    }

    return element;
  }

  function editTask(e) {
    const listItem = e.target.parentElement;
    const title = listItem.querySelector("article h4").textContent;
    const task = tasks.find((task) => task.title === title);

    Object.keys(inputFields).forEach((key) => {
      inputFields[key].value = task[key.toLowerCase()];
    });

    tasks.splice(tasks.indexOf(task), 1);
    listItem.remove();
  }

  function postTask(e) {
    const listItem = e.target.parentElement;
    const title = listItem.querySelector("article h4").textContent;
    const task = tasks.find((task) => task.title === title);
    tasks.splice(tasks.indexOf(task), 1);

    listItem.querySelectorAll("button").forEach((btn) => btn.remove());
    listItem.remove();
    selectors["Published List"].appendChild(listItem);
  }
}
