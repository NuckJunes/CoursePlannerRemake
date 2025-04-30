import { HttpHeaders } from "@angular/common/http";

const ROOT = 'https://localHost:7068/';

const httpOptions = { 
    headers: new HttpHeaders({
        'Content-Type': 'application/json',
    }),
    verifySSL: false, //Should check later for adding SSL Cert
}

const parseJSON = (response: any) => {
    if(response.status === 204 || response.status === 205) {
        return null;
    }
    return response.json();
};

const checkStatus = (response: any) => {
    if(response.status >= 200 && response.status < 300) {
        return response;
    }
    const error: any = new Error(response.statusText);
    error.response = response;
    throw error; //Check later for better error handling
};

/*
    @param String endpoint  A endpoint to call (ex: course)
    @param String[] options A array of options (MUST BE IN ORDER, ex: [id, 'courses'])
    @return {object}        The Response Data
*/
export const Get = (endpoint: String, options: String[]) => {
    let url = ROOT + endpoint;
    options.forEach((element) => {
        url = url + '/' + element;
    });
    return fetch(url, {
        method: 'GET',
    })
    .then(checkStatus)
    .then(parseJSON);
};

/*
    @param String endpoint  A endpoint to call (ex: course)
    @param String[] options A array of options (MUST BE IN ORDER, ex: [id, 'courses'])
    @return {object}        The Response Data
*/
export const Delete = (endpoint: String, options: String[]) => {
    let url = ROOT + endpoint;
    options.forEach((element) => {
        url = url + '/' + element;
    });
    return fetch(url, {
        method: 'DELETE',
    })
    .then(checkStatus)
    .then(parseJSON);
};

/*
    @param String endpoint      A endpoint to call (ex: course)
    @param String[] options     A array of options (MUST BE IN ORDER, ex: [id, 'courses'])
    @param {object} optionsBody A object that contains values for the POST method body (ex: {username: "name"})
    @return {object}            The Response Data
*/
export const Post = (endpoint: String, options: String[], optionsBody: any) => {
    let url = ROOT + endpoint;
    options.forEach((element) => {
        url = url + '/' + element;
    });
    return fetch(url, {
        method: "POST",
        body: JSON.stringify(optionsBody),
        headers: {
            "Content-Type": "application/json",
        },
    })
    .then(checkStatus)
    .then(parseJSON);
};

/*
    @param String endpoint      A endpoint to call (ex: course)
    @param String[] options     A array of options (MUST BE IN ORDER, ex: [id, 'courses'])
    @param {object} optionsBody A object that contains values for the POST method body (ex: {username: "name"})
    @return {object}            The Response Data
*/
export const Patch = (endpoint: String, options: String[], optionsBody: any) => {
    let url = ROOT + endpoint;
    options.forEach((element) => {
        url = url + '/' + element;
    });
    return fetch(url, {
        method: 'PATCH',
        body: JSON.stringify(optionsBody),
        headers: {
            'Content-Type': 'application/json',
        },
    })
    .then(checkStatus)
    .then(parseJSON);
};
