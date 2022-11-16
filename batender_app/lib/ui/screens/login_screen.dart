// ignore_for_file: must_be_immutable

import 'package:bartender_app/blocs/auth/auth_bloc.dart';
import 'package:bartender_app/routes.dart';
import 'package:bartender_app/ui/controls/field_outline.dart';
import 'package:bartender_app/ui/controls/fill_btn.dart';
import 'package:bartender_app/ui/widgets/card_custom.dart';
import 'package:bartender_app/ui/widgets/processing.dart';
import 'package:bartender_app/utils/const.dart';
import 'package:bartender_app/utils/function_common.dart';
import 'package:bartender_app/utils/ui_setting.dart';
import 'package:bartender_app/utils/enum.dart';
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
    var cardWidth = screenWidth * .5;
    var cardHeight = screenHeight * .5;

    return BlocListener<AuthBloc, AuthState>(
      listener: (context, state) {
        if (state is SubmitSuccessState) {
          Navigator.pushNamed(context, RouteName.home);
        }
      },
      child: Container(
        decoration: const BoxDecoration(
          gradient: LinearGradient(
            begin: Alignment.topLeft,
            end: Alignment(.5, 1),
            colors: <Color>[
              // Color(0xFFBBDEFB),
              // Color(0xFF64B5F6),
              MColor.white,
              MColor.primaryGreen,
              // Color(0xFF1976D2),
              // Color(0xFF0D47A1),
            ], // Gradient from https://learnui.design/tools/gradient-generator.html
            tileMode: TileMode.mirror,
          ),
        ),
        child: BlocBuilder<AuthBloc, AuthState>(
          builder: (context, state) {
            String? errUsername;
            String? errPassword;
            bool isLoading = false;
            if (state is DataInvalidState) {
              errUsername = state.errUsername;
              errPassword = state.errPassword;
            } else if (state is SubmitFailState) {
              Fn.showToast(EToast.danger, state.errMsg);
            } else if (state is SubmittingState) {
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
                                fontSize: 30,
                              ),
                            ), // ----------------------------------------------------------------------------------------------------
                            const SizedBox(height: 10),
                            // Username
                            FieldOutnine(
                              labelText: 'Tên đăng nhập',
                              controller: usernameTEC,
                              errorText: errUsername,
                              onChanged: (val) {
                                BlocProvider.of<AuthBloc>(context)
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
                                BlocProvider.of<AuthBloc>(context)
                                    .add(DataChangedEvent(
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
                                    .add(SubmittedEvent(
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
    );
  }
}
