import 'package:blue_bird_coffee_mobile/blocs/login/login_bloc.dart';
import 'package:blue_bird_coffee_mobile/routes.dart';
import 'package:blue_bird_coffee_mobile/ui/controls/field_outline.dart';
import 'package:blue_bird_coffee_mobile/ui/controls/fill_btn.dart';
import 'package:blue_bird_coffee_mobile/utils/ui_setting.dart';
import 'package:blue_bird_coffee_mobile/utils/enum.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
// import 'dart:io' show Platform;
// Platform.localHostname

class LoginScreen extends StatelessWidget {
  const LoginScreen({super.key});

  @override
  Widget build(BuildContext context) {
    // var auth_bloc = new AuthBloc();
    var login_bloc = new LoginBloc();
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
              child: BlocListener<LoginBloc, LoginState>(
                listener: (context, state) {
                  if (state is SubmitSuccessState) {
                    Navigator.pushNamed(context, RouteName.Home);
                  }
                },
                child: BlocBuilder<LoginBloc, LoginState>(
                  builder: (context, state) {
                    String? errUsername;
                    String? errPassword;
                    if (state is DataInvalidState) {
                      errUsername = state.errUsername;
                      errPassword = state.errPassword;
                    }
                    return Column(
                      mainAxisAlignment: MainAxisAlignment.center,
                      // crossAxisAlignment: CrossAxisAlignment.center,
                      children: [
                        Text(
                          "Blue Bird Coffee",
                          style: TextStyle(
                            color: MColor.primary,
                            fontWeight: FontWeight.bold,
                            fontSize: 30,
                          ),
                        ), // ----------------------------------------------------------------------------------------------------
                        const SizedBox(height: 20),
                        // Username
                        FieldOutnine(
                          labelText: 'Tên đăng nhập',
                          controller: usernameTEC,
                          errorText: errUsername,
                          onChanged: (val) {
                            BlocProvider.of<LoginBloc>(context)
                                .add(DataChangedEvent(
                              usernameTEC.text,
                              passwordTEC.text,
                            ));
                          },
                        ), // ----------------------------------------------------------------------------------------------------
                        // Password
                        FieldOutnine(
                          labelText: 'Mật khẩu',
                          controller: passwordTEC,
                          eFieldType: EFieldType.password,
                          errorText: errPassword,
                          onChanged: (val) {
                            BlocProvider.of<LoginBloc>(context)
                                .add(DataChangedEvent(
                              usernameTEC.text,
                              passwordTEC.text,
                            ));
                          },
                        ), // ----------------------------------------------------------------------------------------------------
                        const SizedBox(height: 20),
                        FillBtn(
                          title: "Đăng nhập",
                          onPressed: () {
                            BlocProvider.of<LoginBloc>(context)
                                .add(SubmittedEvent(
                              context,
                              usernameTEC.text,
                              passwordTEC.text,
                            ));
                          },
                        ),
                      ],
                    );
                  },
                ),
              ),
            ),
          ),
        ),
      ),
    );
  }
}
