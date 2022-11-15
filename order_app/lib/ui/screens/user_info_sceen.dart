// ignore_for_file: must_be_immutable

import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:orderr_app/blocs/user_info/user_info_bloc.dart';
import 'package:orderr_app/models/order/order_create_model.dart';
import 'package:orderr_app/routes.dart';
import 'package:orderr_app/ui/controls/field_outline.dart';
import 'package:orderr_app/ui/controls/fill_btn.dart';
import 'package:orderr_app/ui/widgets/frame_common.dart';
import 'package:orderr_app/ui/widgets/popup_confirm.dart';
import 'package:orderr_app/ui/widgets/processing.dart';
import 'package:orderr_app/ui/widgets/title_custom.dart';
import 'package:orderr_app/utils/enum.dart';
import 'package:orderr_app/utils/function_common.dart';
import 'package:orderr_app/utils/ui_setting.dart';

class UserInfoScreen extends StatelessWidget {
  final OrderCreateModel? order;
  UserInfoScreen({
    super.key,
    this.order,
  });

  var fullNameController = TextEditingController();
  String? errName;
  var oldPassController = TextEditingController();
  String? errOP;
  var newPassController = TextEditingController();
  String? errNP;
  var newPassConfirmController = TextEditingController();
  String? errNPC;

  bool isLoading = false;
  bool isShowPopupConfirmPassword = false;

  bool isErrName = true;
  bool isErrOP = true;
  bool isErrNP = true;
  bool isErrNPC = true;
  bool isErrPass = true;

  TextStyle textStyle = const TextStyle(
    fontWeight: FontWeight.bold,
    fontSize: ScreenSetting.fontSize,
  );

  @override
  Widget build(BuildContext context) {
    return MainFrame(
      showBackBtn: true,
      showUserInfo: false,
      showLogoutBtn: false,
      title: 'Thông tin cá nhân',
      onWillPop: () => _back(context),
      onClickBackBtn: () => _back(context),
      child: Stack(
        children: [
          _main(context),
          _processState(context),
          _popupConfirmChangePassword(context)
        ],
      ),
    );
  }

  Widget _processState(BuildContext context) {
    return BlocBuilder<UserInfoBloc, UserInfoState>(
      builder: (context, state) {
        bool isLoading = false;
        String loadingMsg = "";
        if (state is UIErrorState) {
          Fn.showToast(eToast: EToast.danger, msg: state.errMsg.toString());
        } else if (state is UIUpdatedLoadingState) {
          isLoading = state.isLoading;
          loadingMsg = state.labelLoading;
        }
        return Processing(msg: loadingMsg, show: isLoading);
      },
    );
  }

  Widget _main(BuildContext context) {
    return Padding(
      padding: EdgeInsets.symmetric(
        vertical: ScreenSetting.padding_all,
        horizontal: Fn.getScreenWidth(context) * .05,
      ),
      child: SingleChildScrollView(
        child: Column(
          children: [
            SizedBox(
              height: Fn.getScreenHeight(context) * .3,
              child: _info(context),
            ),
            const Divider(color: MColor.primaryBlack, thickness: 3),
            SizedBox(
              height: Fn.getScreenHeight(context) * .5,
              child: _password(context),
            ),
          ],
        ),
      ),
    );
  }

  Widget _info(BuildContext context) {
    return SizedBox(
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          const TitleCustom(title: 'Cập nhật thông tin'),
          const SizedBox(height: 30),
          Row(children: [Text('Họ & Tên', style: textStyle)]),
          BlocBuilder<UserInfoBloc, UserInfoState>(
            builder: (context, state) {
              if (state is UIInvalidFullNameState) {
                errName = state.errMsg;
              }
              var isEmptyFN = fullNameController.text.isEmpty;
              isErrName = (errName != null && errName != '') || isEmptyFN;
              return FieldOutline(
                controller: fullNameController,
                hintText: 'Nhập Họ & Tên',
                paddingHorizontal: 0,
                errorText: errName,
                onChanged: (val) {
                  errOP = null;
                  errNP = null;
                  errNPC = null;
                  BlocProvider.of<UserInfoBloc>(context)
                      .add(UIChangeFullNameEvent(val));
                },
              );
            },
          ),
          const SizedBox(height: 30),
          BlocBuilder<UserInfoBloc, UserInfoState>(
            builder: (context, state) {
              return FillBtn(
                label: 'Cập nhật',
                btnBgColor: isErrName ? EColor.dark : EColor.primary,
                onPressed: () {
                  if (!isErrName) {}
                },
              );
            },
          ),
        ],
      ),
    );
  }

  Widget _password(BuildContext context) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        const TitleCustom(title: 'Đổi mật khẩu'),
        const SizedBox(height: 30),
        Row(children: [Text('Mật khẩu cũ', style: textStyle)]),
        BlocBuilder<UserInfoBloc, UserInfoState>(
          builder: (context, state) {
            if (state is UIInvalidOldPassState) {
              errOP = state.errMsg;
            }
            var isEmptyOP = oldPassController.text.isEmpty;
            isErrOP = (errOP != null && errOP != '') || isEmptyOP;
            isErrPass = isErrOP || isErrNP || isErrNPC;
            return FieldOutline(
              controller: oldPassController,
              hintText: 'Nhập mật khẩu cũ',
              paddingHorizontal: 0,
              eFieldType: EFieldType.password,
              errorText: errOP,
              onChanged: (val) {
                errName = null;
                BlocProvider.of<UserInfoBloc>(context)
                    .add(UIChangeOldPassEvent(val));
              },
            );
          },
        ),
        const SizedBox(height: 20),
        Row(children: [Text('Mật khẩu mới', style: textStyle)]),
        BlocBuilder<UserInfoBloc, UserInfoState>(
          builder: (context, state) {
            if (state is UIInvalidNewPassState) {
              errNP = state.errMsg;
            } else if (state is UIInvalidNewPassConfirmState) {
              errNP = state.errMsgNewPass;
            }
            var isEmptyNP = newPassController.text.isEmpty;
            isErrNP = (errNP != null && errNP != '') || isEmptyNP;
            isErrPass = isErrOP || isErrNP || isErrNPC;
            return FieldOutline(
              controller: newPassController,
              hintText: 'Nhập mật khẩu mới',
              paddingHorizontal: 0,
              eFieldType: EFieldType.password,
              errorText: errNP,
              onChanged: (val) {
                errName = null;
                BlocProvider.of<UserInfoBloc>(context)
                    .add(UIChangeNewPassEvent(val));
              },
            );
          },
        ),
        const SizedBox(height: 20),
        Row(children: [Text('Xác nhận mật khẩu mới', style: textStyle)]),
        BlocBuilder<UserInfoBloc, UserInfoState>(
          builder: (context, state) {
            if (state is UIInvalidNewPassConfirmState) {
              errNP = state.errMsgNewPass;
              errNPC = state.errMsgNewPassConfirm;
            }
            var isEmptyNP = newPassController.text.isEmpty;
            var isEmptyNPC = newPassConfirmController.text.isEmpty;
            isErrNP = (errNP != null && errNP != '') || isEmptyNP;
            isErrNPC = (errNPC != null && errNPC != '') || isEmptyNPC;
            isErrPass = isErrOP || isErrNP || isErrNPC;
            return FieldOutline(
              controller: newPassConfirmController,
              hintText: 'Nhập lại mật khẩu mới',
              paddingHorizontal: 0,
              eFieldType: EFieldType.password,
              errorText: errNPC,
              onChanged: (val) {
                errName = null;
                BlocProvider.of<UserInfoBloc>(context).add(
                    UIChangeNewPassConfirmEvent(newPassController.text, val));
              },
            );
          },
        ),
        const SizedBox(height: 30),
        BlocBuilder<UserInfoBloc, UserInfoState>(
          builder: (context, state) {
            return FillBtn(
              label: 'Đổi mật khẩu',
              btnBgColor: isErrPass ? EColor.dark : EColor.primary,
              onPressed: () {
                if (!isErrPass) {}
              },
            );
          },
        ),
      ],
    );
  }

  Widget _popupConfirmChangePassword(BuildContext context) {
    return PopupConfirm(
      visible: isShowPopupConfirmPassword,
      title: 'Xác nhận thay đổi mật khẩu',
      onLeftBtnPressed: () {},
      onRightBtnPressed: () {},
    );
  }

  _back(BuildContext context) => Fn.pushScreen(
        context,
        RouteName.pickTable,
        arguments: [order],
      );
}