function lockedProfile() {
  fetch("http://localhost:3030/jsonstore/advanced/profiles")
    .then((res) => res.json())
    .then((profiles) => {
      let userCount = 0;
      for (const profileObj of Object.values(profiles)) {
        const div = document.createElement("div");
        div.classList.add("profile");
        userCount++;

        div.innerHTML = `
          <img src="./iconProfile2.png" class="userIcon" />
          <label>Lock</label>
          <input type="radio" name="user${userCount}Locked" value="lock" checked />
          <label>Unlock</label>
          <input type="radio" name="user${userCount}Locked" value="unlock" /><br />
          <hr />
          <label>Username</label>
          <input type="text" name=user${userCount}Username" value="${profileObj.username}" disabled readonly />
          <div class="user${userCount}HiddenFields" hidden>
            <hr />
            <label>Email:</label>
            <input type="email" name="user${userCount}Email" value="${profileObj.email}" disabled readonly />
            <label>Age:</label>
            <input type="text" name="user${userCount}Age" value="${profileObj.age}" disabled readonly />
          </div>
          <button>Show more</button>`;

        document.getElementById("main").appendChild(div);
      }

      const profilesDiv = Array.from(document.querySelectorAll("div.profile"));
      profilesDiv.forEach((profile) => {
        const unlockRadio = profile.querySelector("input[value=unlock]");
        const button = profile.querySelector("button");
        const divToShow = profile.querySelector("div");
        button.addEventListener("click", (e) => {
          if (unlockRadio.checked) {
            divToShow.hidden = divToShow.hidden === true ? false : true;
            button.innerText =
              button.innerText === "Show more" ? "Hide it" : "Show more";
          }
        });
      });
    });
}
