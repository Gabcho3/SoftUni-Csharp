async function attachEvents() {
  const submitButton = document.getElementById("submit");

  submitButton.addEventListener("click", (e) => {
    const inputs = Array.from(document.querySelectorAll("input[type=text"));
    const student = {};
    inputs.forEach((input) => {
      if (input.value) {
        student[input.name] = input.value;
      }
    });

    fetch("http://localhost:3030/jsonstore/collections/students", {
      method: "post",
      body: JSON.stringify(student),
    });

    showResults();
  });
}
function showResults() {
  document.querySelector("#results tbody").innerHTML = "";

  fetch("http://localhost:3030/jsonstore/collections/students")
    .then((res) => res.json())
    .then((students) => {
      for (const student of Object.values(students)) {
        const tr = document.createElement("tr");
        for (const [key, value] of Object.entries(student)) {
          if (key === "_id") {
            continue;
          }
          const th = document.createElement("th");

          if (key === "grade") {
            th.textContent = Number(value).toFixed(2);
          } else {
            th.textContent = value;
          }

          tr.appendChild(th);
        }
        if (tr.innerHTML) {
          document.querySelector("#results tbody").appendChild(tr);
        }
      }
    });
}
attachEvents();
