import 'package:blue_bird_coffee_mobile/blocs/auth/auth_bloc.dart';
import 'package:blue_bird_coffee_mobile/screens/controls/field_outline.dart';
import 'package:blue_bird_coffee_mobile/screens/controls/fill_btn.dart';
import 'package:blue_bird_coffee_mobile/utils/ui_setting.dart';
import 'package:blue_bird_coffee_mobile/utils/enum.dart';
import 'package:flutter/material.dart';
// import 'dart:io' show Platform;
// Platform.localHostname

class LoginScreen extends StatelessWidget {
  const LoginScreen({super.key});

  @override
  Widget build(BuildContext context) {
    // var auth_bloc = new AuthBloc();
    var usernameTEC = TextEditingController();
    var passwordTEC = TextEditingController();

    var screenWidth = MediaQuery.of(context).size.width;
    var screenHeight = MediaQuery.of(context).size.height;
    var cardWidth = screenWidth * .85;
    var cardHeight = screenHeight * .45;

    return Container(
      // color: MColor.primary,
      decoration: const BoxDecoration(
        gradient: LinearGradient(
          begin: Alignment.topLeft,
          end: Alignment(.5, 1),
          colors: <Color>[
            Color(0xFFBBDEFB),
            Color(0xFF64B5F6),
            MColor.primary,
            Color(0xFF1976D2),
            Color(0xFF0D47A1),
          ], // Gradient from https://learnui.design/tools/gradient-generator.html
          tileMode: TileMode.mirror,
        ),
      ),
      child: Center(
        child: Card(
          elevation: 80,
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(CardSetting.border_radius),
          ),
          child: SizedBox(
            width: cardWidth,
            height: cardHeight,
            child: Padding(
              padding: const EdgeInsets.all(30),
              child: Form(
                key: GlobalKey<FormState>(),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  // crossAxisAlignment: CrossAxisAlignment.center,
                  children: [
                    const Text(
                      "Blue Bird Coffee",
                      style: TextStyle(
                        color: MColor.primary,
                        fontWeight: FontWeight.bold,
                        fontSize: 30,
                      ),
                    ),
                    const SizedBox(height: 20),
                    // Username
                    FieldOutnine(
                      labelTxt: 'Tên đăng nhập',
                      controller: usernameTEC,
                      validator: ((value) {
                        if (value == null || value.isEmpty) {
                          return "Tên đăng nhập không được trống!";
                        }
                        return null;
                      }),
                    ),
                    // Password
                    FieldOutnine(
                      labelTxt: 'Mật khẩu',
                      controller: passwordTEC,
                      eFieldType: EFieldType.password,
                      validator: ((value) {
                        if (value == null || value.isEmpty) {
                          return "Mật khẩu không được trống!";
                        }
                        return null;
                      }),
                    ),
                    const SizedBox(height: 20),
                    FillBtn(
                      title: "Đăng nhập",
                      onPressed: () => {},
                    ),
                  ],
                ),
              ),
            ),
          ),
        ),
      ),
    );
  }
}
