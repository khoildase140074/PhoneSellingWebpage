$(document).ready(() => {
    $("#login-form").validate({
        rules: {
            username: {
                required: true,
                rangelength: [1, 100],
            }, password: {
                required: true,
                rangelength: [1, 20],
            }
        }, messages: {
            username: {
                required: "Please input something in Username",
                rangelength: "1 -100"
            }, password: {
                required: "Please input something in Password such as : ****",
                rangelength: "1 -20"
            }
        }, errorPlacement: (label, element) => {
            label.addClass('error');
            label.insertAfter(element);
        }
    });
});

$(document).ready(() => {
    $("#create-form").validate({
        rules: {
            id: {
                required: true,
                rangelength: [8, 20],
            }, password: {
                required: true,
                rangelength: [8, 20],
            }, fullname: {
                required: true,
                rangelength: [2, 50],
            }, phonenumber: {
                required: true,
                rangelength: [10, 11],
            }, address: {
                required: true,
                rangelength: [1, 100],
            }, date: {
                required: true,
                rangelength: [1, 100],
            }
        }, messages: {
            id: {
                required: "Please input something in Username",
                rangelength: "1 - 20"
            }, password: {
                required: "Please input something in Password",
                rangelength: "1 - 20"
            }, fullname: {
                required: "Please input something in Fullname",
                rangelength: "2 - 50"
            }, phonenumber: {
                required: "Please input something in PhoneNumber",
                rangelength: "Must between 10 - 11 digits"
            }, address: {
                required: "Please input something in Address",
                rangelength: "1 - 100"
            }, date: {
                required: "Please input something in Date Of Birth",
                rangelength: "1 - 100"
            }
        }, errorPlacement: (label, element) => {
            label.addClass('error');
            label.insertAfter(element);
        }
    });
});

$(document).ready(() => {
    $("#update-form").validate({
        rules: {
            id: {
                required: true,
                rangelength: [8, 20],
            }, "password": {
                required: true,
                rangelength: [8, 20],
            }, confirm: { 
                rangelength: [8, 20],
                equalTo: '[name="password"]'
            }, fullname: {
                required: true,
                rangelength: [2, 50],
            }, phonenumber: {
                required: true,
                rangelength: [10, 11],
            }, address: {
                required: true,
                rangelength: [1, 100],
            }, date: {
                required: true,
                rangelength: [1, 100],
            }
        }, messages: {
            id: {
                required: "Please input something in Username",
                rangelength: "length = 8 - 20"
            }, password: {
                required: "Please input something in Password",
                rangelength: "length = 8 - 20"
            }, confirm: {
                equalTo: "Please enter the confirm the same with the password!",
                rangelength: "length = 8 - 20",
            }, fullname: {
                required: "Please input something in Fullname",
                rangelength: "2 -50"
            }, phonenumber: {
                required: "Please input something in PhoneNumber",
                rangelength: "Must between 10 - 11 digits"
            }, address: {
                required: "Please input something in Address",
                rangelength: "1 -100"
            }, date: {
                required: "Please input something in Date Of Birth",
                rangelength: "1 -100"
            }
        }, errorPlacement: (label, element) => {
            label.addClass('error');
            label.insertAfter(element);
        }
    });
});

$(document).ready(() => {
    $("#createPhone-form").validate({
        rules: {
            name: {
                required: true,
                rangelength: [1, 100],
            }, price: {
                required: true,
                min: 1
            }, quantity: {
                required: true,
                min: 1
            }
        }, messages: {
            name: {
                required: "Please input something in Phone Name",
                rangelength: "1 -100"
            }, price: {
                required: "Please input Price",
                min: "Everything Has Its Price!"
            }, quantity: {
                required: "Please input Quantity",
                min: "We Need Something To Store Bruh!"
            }
        }, errorPlacement: (label, element) => {
            label.addClass('error');
            label.insertAfter(element);
        }
    });
});

$(document).ready(() => {
    $("#updatePhone-form").validate({
        rules: {
            name: {
                required: true,
                rangelength: [1, 100],
            }, price: {
                required: true,
                min: 1
            }, quantity: {
                required: true,
                min: 1
            }
        }, messages: {
            name: {
                required: "Please input something in Phone Name",
                rangelength: "1 - 100"
            }, price: {
                required: "Please input Price",
                min: "Everything Has Its Price!"
            }, quantity: {
                required: "Please input Quantity",
                min: "We Need Something To Store Bruh!"
            }
        }, errorPlacement: (label, element) => {
            label.addClass('error');
            label.insertAfter(element);
        }
    });
});

$(document).ready(() => {
    $("#add-cart-form").validate({
        rules: {
            address: {
                required: true,
                rangelength: [1, 200]
            }
            }, messages: {
                address: {
                    required: "Please input something in the Address!",
                    rangelength: "1 - 200"
                }
            }, errorPlacement: (label, element) => {
                label.addClass('error');
                label.insertAfter(element);
            }
        });
});


