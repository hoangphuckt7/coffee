// ignore_for_file: must_be_immutable

import 'package:orderr_app/blocs/auth/auth_bloc.dart';
import 'package:orderr_app/routes.dart';
import 'package:orderr_app/ui/controls/field_outline.dart';
import 'package:orderr_app/ui/controls/fill_btn.dart';
import 'package:orderr_app/ui/widgets/card_custom.dart';
import 'package:orderr_app/ui/widgets/processing.dart';
import 'package:orderr_app/utils/const.dart';
import 'package:orderr_app/utils/function_common.dart';
import 'package:orderr_app/utils/ui_setting.dart';
import 'package:orderr_app/utils/enum.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class LoginScreen extends StatelessWidget {
  var usernameTEC = TextEditingController();
  var passwordTEC = TextEditingController();
  LoginScreen({super.key});

  @override
  Widget build(BuildContext context) {
    var screenWidth = Fn.getScreenWidth(context);
    var screenHeight = Fn.getScreenHeight(context);
    var cardWidth = screenWidth * .8;
    var cardHeight = screenHeight * .5;

    return WillPopScope(
      onWillPop: () async => false,
      child: BlocListener<AuthBloc, AuthState>(
        listener: (context, state) {
          if (state is AuthSubmitSuccessState) {
            Fn.pushScreen(context, RouteName.pickTable);
          }
        },
        child: Container(
          decoration: const BoxDecoration(
            gradient: LinearGradient(
              begin: Alignment.topLeft,
              end: Alignment(.5, 1),
              colors: <Color>[
                MColor.white,
                MColor.primaryGreen,
              ], // Gradient from https://learnui.design/tools/gradient-generator.html
              tileMode: TileMode.mirror,
            ),
          ),
          child: BlocBuilder<AuthBloc, AuthState>(
            builder: (context, state) {
              String? errUsername;
              String? errPassword;
              bool isLoading = false;
              if (state is AuthDataInvalidState) {
                errUsername = state.errUsername;
                errPassword = state.errPassword;
              } else if (state is AuthSubmitFailState) {
                Fn.showToast(eToast: EToast.danger, msg: state.errMsg);
              } else if (state is AuthSubmittingState) {
                isLoading = true;
              }
              return Stack(
                children: [
                  Center(
                    child: CardCustom(
                      child: SizedBox(
                        width: cardWidth,
                        height: cardHeight,
                        child: Padding(
                          padding: const EdgeInsets.all(30),
                          child: Column(
                            mainAxisAlignment: MainAxisAlignment.center,
                            children: [
                              const Text(
                                AppInfo.Name,
                                style: TextStyle(
                                  color: MColor.primaryBlack,
                                  fontWeight: FontWeight.bold,
                                  fontSize: 25,
                                ),
                              ), // ----------------------------------------------------------------------------------------------------
                              const SizedBox(height: 10),
                              // Username
                              FieldOutline(
                                labelText: 'Tên đăng nhập',
                                controller: usernameTEC,
                                errorText: errUsername,
                                onChanged: (val) {
                                  BlocProvider.of<AuthBloc>(context)
                                      .add(AuthDataChangedEvent(
                                    usernameTEC.text,
                                    passwordTEC.text,
                                  ));
                                },
                              ), // ----------------------------------------------------------------------------------------------------
                              // Password
                              FieldOutline(
                                labelText: 'Mật khẩu',
                                controller: passwordTEC,
                                eFieldType: EFieldType.password,
                                errorText: errPassword,
                                onChanged: (val) {
                                  BlocProvider.of<AuthBloc>(context)
                                      .add(AuthDataChangedEvent(
                                    usernameTEC.text,
                                    passwordTEC.text,
                                  ));
                                },
                              ), // ----------------------------------------------------------------------------------------------------
                              const SizedBox(height: 20),
                              FillBtn(
                                label: "Đăng nhập",
                                onPressed: () {
                                  FocusManager.instance.primaryFocus?.unfocus();
                                  BlocProvider.of<AuthBloc>(context)
                                      .add(AuthSubmittedEvent(
                                    usernameTEC.text,
                                    passwordTEC.text,
                                  ));
                                },
                              ),
                            ],
                          ),
                        ),
                      ),
                    ),
                  ),
                  Processing(
                    show: isLoading,
                  )
                ],
              );
            },
          ),
        ),
      ),
    );
  }
}
