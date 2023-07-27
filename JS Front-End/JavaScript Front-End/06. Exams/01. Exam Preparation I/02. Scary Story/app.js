window.addEventListener("load", solve);

function solve() {
  const publishButton = document.getElementById("form-btn");

  publishButton.addEventListener("click", (e) => {
    const firstName = document.getElementById("first-name").value;
    const lastName = document.getElementById("last-name").value;
    const age = document.getElementById("age").value;
    const storyTitle = document.getElementById("story-title").value;
    const genre = document.getElementById("genre").value;
    const text = document.getElementById("story").value;

    if (!firstName || !lastName || !age || !storyTitle || !genre || !text) {
      return;
    }
    const story = {
      FirstName: firstName,
      LastName: lastName,
      Age: age,
      Title: storyTitle,
      Genre: genre,
      Text: text,
    };

    previewStory(story);
    editStory(story);
    saveStory();
    deleteStory();
  });

  function previewStory(story) {
    const listItem = document.createElement("li");
    listItem.classList.add("story-info");

    const article = document.createElement("article");
    const h4 = document.createElement("h4");

    for (const [key, value] of Object.entries(story)) {
      if (key === "FirstName") {
        h4.textContent = `Name: ${value} `;
      } else if (key === "LastName") {
        h4.textContent += value;
        article.appendChild(h4);
      } else {
        const p = document.createElement("p");

        if (key === "Text") {
          p.textContent = value;
        } else {
          p.textContent = `${key}: ${value}`;
        }
        article.appendChild(p);
      }
    }
    listItem.appendChild(article);

    const buttonContent = ["Save story", "Edit story", "Delete story"];
    const buttonClasses = ["save-btn", "edit-btn", "delete-btn"];
    for (let i = 0; i < buttonContent.length; i++) {
      const button = document.createElement("button");
      button.classList.add(buttonClasses[i]);
      button.textContent = buttonContent[i];

      listItem.appendChild(button);
    }

    document.getElementById("preview-list").appendChild(listItem);
    publishButton.disabled = true;
    clearFields();
  }

  function clearFields() {
    const fields = Array.from(document.querySelectorAll("form input"));
    fields.pop(); //publish button
    fields.forEach((field) => {
      field.value = "";
    });
    document.querySelector("textarea").value = "";
  }

  function editStory(story) {
    const editButton = document.querySelector(".edit-btn");
    editButton.addEventListener("click", (e) => {
      const fields = Array.from(document.querySelectorAll("form input"));
      fields.pop(); //publish button
      const storyValues = Object.values(story);

      for (let i = 0; i < storyValues.length - 2; i++) {
        if (i === 2) {
          //KEY -> age
          fields[i].value = Number(storyValues[i]);
        } else {
          fields[i].value = storyValues[i];
        }
      }
      document.querySelector("textarea").value = story.Text;
      document.querySelector(".story-info").remove();
      publishButton.disabled = false;
    });
  }

  function saveStory() {
    const saveButton = document.querySelector(".save-btn");
    saveButton.addEventListener("click", (e) => {
      document.getElementById("main").innerHTML =
        "<h1>Your scary story is saved!</h1>";
    });
  }

  function deleteStory() {
    const deleteButton = document.querySelector(".delete-btn");
    deleteButton.addEventListener("click", (e) => {
      document.querySelector(".story-info").remove();
      publishButton.disabled = false;
    });
  }
}
