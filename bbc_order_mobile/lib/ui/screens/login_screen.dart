// ignore_for_file: must_be_immutable

import 'package:bbc_order_mobile/blocs/login/login_bloc.dart';
import 'package:bbc_order_mobile/routes.dart';
import 'package:bbc_order_mobile/ui/controls/field_outline.dart';
import 'package:bbc_order_mobile/ui/controls/fill_btn.dart';
import 'package:bbc_order_mobile/ui/widgets/card_custom.dart';
import 'package:bbc_order_mobile/ui/widgets/processing.dart';
import 'package:bbc_order_mobile/utils/const.dart';
import 'package:bbc_order_mobile/utils/function_common.dart';
import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:bbc_order_mobile/utils/enum.dart';
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
    var cardHeight = screenHeight * .4;

    return BlocListener<LoginBloc, LoginState>(
      listener: (context, state) {
        if (state is SubmitSuccessState) {
          Navigator.pushNamed(context, RouteName.pickTable);
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
        child: BlocBuilder<LoginBloc, LoginState>(
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
                                fontSize: 25,
                              ),
                            ), // ----------------------------------------------------------------------------------------------------
                            const SizedBox(height: 10),
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
                                FocusManager.instance.primaryFocus?.unfocus();
                                BlocProvider.of<LoginBloc>(context)
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
