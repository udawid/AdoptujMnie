// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const header = document.querySelector("header");

window.addEventListener("scroll", function () {
	header.classList.toggle("sticky", window.scrollY > 0);
});

let menu = document.querySelector('#menu-icon');
let navlist = document.querySelector('.navlist');

menu.onclick = () => {
	menu.classList.toggle('bx-x');
	navlist.classList.toggle('active');
};

window.onscroll = () => {
	menu.classList.remove('bx-x');
	navlist.classList.remove('active');
};

const sr = ScrollReveal({
	distance: '45px',
	duration: 1400,
	reset: true
})

sr.reveal('.home-text', { delay: 350, origin: 'left' })
sr.reveal('.home-img', { delay: 350, origin: 'right' })

sr.reveal('.sub-service,.about,.adopcja,.service,.cta,.contact', { delay: 200, origin: 'bottom' })

