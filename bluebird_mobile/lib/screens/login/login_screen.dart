import 'package:bluebird_mobile/blocs/auth/auth_bloc.dart';
import 'package:bluebird_mobile/controls/field_outline.dart';
import 'package:bluebird_mobile/controls/fill_btn.dart';
import 'package:bluebird_mobile/utils/app_setting.dart';
import 'package:bluebird_mobile/utils/const.dart';
import 'package:bluebird_mobile/utils/enum.dart';
import 'package:flutter/material.dart';

class LoginScreen extends StatelessWidget {
  const LoginScreen({super.key});

  @override
  Widget build(BuildContext context) {
    var auth_bloc = new AuthBloc();
    var usernameTEC = TextEditingController();
    var passwordTEC = TextEditingController();

    var screenWidth = MediaQuery.of(context).size.width;
    var screenHeight = MediaQuery.of(context).size.height;
    var cardWidth = screenWidth * .85;
    var cardHeight = screenHeight * .45;

    return Container(
      color: MColor.primary,
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
                  ),
                  // Password
                  FieldOutnine(
                    labelTxt: 'Mật khẩu',
                    controller: passwordTEC,
                    eFieldType: EFieldType.password,
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
    );
  }
}
