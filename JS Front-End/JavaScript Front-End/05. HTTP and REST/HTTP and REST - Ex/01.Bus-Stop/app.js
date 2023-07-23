function getInfo() {
  const busStopId = document.querySelector("#stopId").value;
  const stopName = document.querySelector("#stopName");
  const list = document.querySelector("#buses");

  list.innerHTML = "";

  fetch(`http://localhost:3030/jsonstore/bus/businfo/${busStopId}`)
    .then((res) => res.json())
    .then((busStop) => {
      stopName.textContent = busStop.name;

      const data = Object.entries(busStop.buses);
      data.forEach(([busId, time]) => {
        const item = document.createElement("li");
        item.textContent = `Bus ${busId} arrives in ${time} minutes`;

        list.appendChild(item);
      });
    })
    .catch(() => {
      stopName.textContent = "Error";
    });
}
