function attachEventsListeners() {
  const daysButton = document.getElementById("daysBtn");
  const hoursButton = document.getElementById("hoursBtn");
  const minutesButton = document.getElementById("minutesBtn");
  const secondsButton = document.getElementById("secondsBtn");

  daysButton.addEventListener("click", convertDays);
  hoursButton.addEventListener("click", (e) => {
    const hours = Number(document.getElementById("hours").value);
    document.getElementById("days").value = hours / 24;
    convertDays();
  });

  minutesButton.addEventListener("click", (e) => {
    const minutes = Number(document.getElementById("minutes").value);
    document.getElementById("days").value = minutes / 1440;
    convertDays();
  });

  secondsButton.addEventListener("click", (e) => {
    const seconds = Number(document.getElementById("seconds").value);
    document.getElementById("days").value = seconds / 86400;
    convertDays();
  });

  function convertDays() {
    const days = Number(document.getElementById("days").value);

    document.getElementById("hours").value = days * 24;
    document.getElementById("minutes").value = days * 1440;
    document.getElementById("seconds").value = days * 86400;
  }
}
