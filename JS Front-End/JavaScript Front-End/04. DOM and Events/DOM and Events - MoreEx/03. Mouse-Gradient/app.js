function attachGradientEvents() {
  const gradient = document.getElementById("gradient-box");
  gradient.addEventListener("mousemove", (e) => {
    const el = document.elementFromPoint(e.clientX, e.clientY);
    const style = window.getComputedStyle(el);
    const a = style.backgroundColor;
    console.log();
  });
}
