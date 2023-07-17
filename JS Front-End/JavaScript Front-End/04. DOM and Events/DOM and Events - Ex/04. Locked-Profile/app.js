function lockedProfile() {
  const profiles = Array.from(document.querySelectorAll("div.profile"));

  profiles.forEach((profile) => {
    const unlockRadio = profile.querySelector("input[value=unlock]");
    const button = profile.querySelector("button");
    const divToShow = profile.querySelector("div");
    button.addEventListener("click", (e) => {
      if (unlockRadio.checked) {
        divToShow.style.display =
          divToShow.style.display === "block" ? "none" : "block";
        button.innerText =
          button.innerText === "Show more" ? "Hide it" : "Show more";
      }
    });
  });
}