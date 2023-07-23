function solve() {
  const departButton = document.querySelector("#depart");
  const arriveButton = document.querySelector("#arrive");
  const infoBox = document.querySelector("#info span");

  let busInfo = {
    name: "",
    next: "depot",
  };

  function depart() {
    fetch(`http://localhost:3030/jsonstore/bus/schedule/${busInfo.next}`)
      .then((res) => res.json())
      .then((busStop) => {
        busInfo = busStop;
        infoBox.textContent = `Next stop ${busInfo.name}`;
      });

    departButton.disabled = true;
    arriveButton.disabled = false;
  }

  async function arrive() {
    infoBox.textContent = `Arriving at  ${busInfo.name}`;
    departButton.disabled = false;
    arriveButton.disabled = true;
  }

  return {
    depart,
    arrive,
  };
}

let result = solve();
