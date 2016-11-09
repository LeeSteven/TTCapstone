/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

 $(document).ready(function() {
                $('#pic1').hover(function() {
                    $(this).addClass('transition');

                }, function() {
                    $(this).removeClass('transition');
                });
            });

            //goto cart
            function gotoCart() {
                window.location = "cart.html"
            }
