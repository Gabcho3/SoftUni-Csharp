const BASE_API = "http://localhost:3030/jsonstore/tasks/";

const inputFields = {
  title: document.getElementById("course-name"),
  type: document.getElementById("course-type"),
  description: document.getElementById("description"),
  teacher: document.getElementById("teacher-name"),
};

const buttons = {
  addButton: document.getElementById("add-course"),
  editButton: document.getElementById("edit-course"),
  loadBuuton: document.getElementById("load-course"),
};

function attachEvennts() {
  buttons.loadBuuton.addEventListener("click", loadCourses);
  buttons.addButton.addEventListener("click", addCourse);
}

let allCourses = [];

async function loadCourses() {
  allCourses = [];
  Object.values(inputFields).forEach((input) => (input.value = ""));
  document.getElementById("list").innerHTML = "";

  const courses = await (await fetch(BASE_API)).json();

  Object.values(courses).forEach((course) => {
    allCourses.push(course);

    const div = createElement("div", ["container"], null, null);
    div.id = course._id;

    createElement("h2", null, course.title, div);
    createElement("h3", null, course.teacher, div);
    createElement("h3", null, course.type, div);
    createElement("h4", null, course.description, div);

    const editButton = createElement(
      "button",
      ["edit-btn"],
      "Edit Course",
      div
    );

    const finishButton = createElement(
      "button",
      ["finish-btn"],
      "Finish Course",
      div
    );

    document.getElementById("list").appendChild(div);

    editButton.addEventListener("click", editConfirmCourse);
    finishButton.addEventListener("click", finishCourse);
  });
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

function addCourse() {
  const course = {
    title: inputFields.title.value,
    type: inputFields.type.value,
    description: inputFields.description.value,
    teacher: inputFields.teacher.value,
  };

  fetch(BASE_API, {
    method: "POST",
    body: JSON.stringify(course),
  });

  loadCourses();
}

function editConfirmCourse(e) {
  buttons.addButton.disabled = true;
  buttons.editButton.disabled = false;

  const _id = e.target.parentElement.id;
  const course = Object.values(allCourses).find((course) => course._id === _id);

  Object.keys(inputFields).forEach(
    (key) => (inputFields[key].value = course[key])
  );

  buttons.editButton.addEventListener("click", (e) => {
    editCourse(_id);
  });
}

function editCourse(_id) {
  buttons.addButton.disabled = false;
  buttons.editButton.disabled = true;

  const course = {
    title: inputFields.title.value,
    type: inputFields.type.value,
    description: inputFields.description.value,
    teacher: inputFields.teacher.value,
    _id,
  };

  fetch(BASE_API + _id, {
    method: "PUT",
    body: JSON.stringify(course),
  });

  loadCourses();
}

function finishCourse(e) {
  const _id = e.target.parentElement.id;

  delete allCourses.find((course) => course._id === _id);

  fetch(BASE_API + _id, {
    method: "DELETE",
  });

  loadCourses();
}
attachEvennts();
