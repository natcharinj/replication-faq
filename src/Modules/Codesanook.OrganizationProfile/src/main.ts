import { HtmlHTMLAttributes } from "react";

document.addEventListener('DOMContentLoaded', _ => {

  // NodeList to Array https://stackoverflow.com/a/44439293/1872200
  const checkboxes = [...document.querySelectorAll<HTMLInputElement>('.part-display-toggle')];
  const form = checkboxes[0].closest<HTMLFormElement>('form');

  toggleFormPart(checkboxes, form);
  //handleFormSubmit(form);

});

function toggleFormPart(elements: HTMLInputElement[], form: HTMLFormElement) {
  elements.forEach(element => {
    element.addEventListener('click', e => {
      const origin = new URL(location.href).origin;

      const actionUrl = form.getAttribute('action');
      const url = new URL(actionUrl, origin);
      url.searchParams.append('toggleDisplayedFormPart', 'true')
      console.log(url);
      form.setAttribute('action', `${url.pathname}${url.search}`);

      const hiddenField = document.createElement('input');
      hiddenField.type = 'hidden';
      hiddenField.name = 'submit.Publish';
      hiddenField.value = 'submit.PublishAndContinue'

      form.appendChild(hiddenField);


      form.submit();
    });
  });
}

// function handleFormSubmit(form: HTMLFormElement) {
//   form.addEventListener('submit', e => {
//     // https://stackoverflow.com/a/56050860/1872200
//     // e.currentTarget.submit();
//   });
// }