const open = document.getElementById("open");
const modal_container = document.getElementById("modal_container");
const close = document.getElementById("close")
const btn = document.getElementById("add-btn")

open.addEventListener("click", () => {
    modal_container.classList.add("show");
});

close.addEventListener("click", () => {
    modal_container.classList.remove("show");
});

btn.addEventListener("click", () => {
    modal_container.classList.remove("show");
});