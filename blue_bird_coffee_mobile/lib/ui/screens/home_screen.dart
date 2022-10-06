import 'dart:developer';

import 'package:blue_bird_coffee_mobile/blocs/home/home_bloc.dart';
import 'package:blue_bird_coffee_mobile/repositories/category_repo.dart';
import 'package:blue_bird_coffee_mobile/routes.dart';
import 'package:blue_bird_coffee_mobile/ui/controls/fill_btn.dart';
import 'package:blue_bird_coffee_mobile/utils/ui_setting.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class HomeScreen extends StatelessWidget {
  const HomeScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return BlocProvider(
      create: (context) =>
          HomeBloc(RepositoryProvider.of<CategoryRepo>(context))
            ..add(FetchDataEvent()),
      child: BlocBuilder<HomeBloc, HomeState>(
        builder: (context, state) {
          if (state is InitialState) {
            log(state.toString());
          } else if (state is FetchDataState) {
            log(state.lstCate[0].description);
          }
          return Container(
            decoration: const BoxDecoration(
              gradient: LinearGradient(
                begin: Alignment.topLeft,
                end: Alignment(.5, 1),
                colors: <Color>[
                  Color(0xFF0D47A1),
                  Color(0xFF1976D2),
                  MColor.primary,
                  Color(0xFF64B5F6),
                  Color(0xFFBBDEFB),
                ], // Gradient from https://learnui.design/tools/gradient-generator.html
                tileMode: TileMode.mirror,
              ),
            ),
            child: Center(
              child: Column(
                children: [
                  Text("Đã đăng nhập thành công ^.^"),
                  FillBtn(
                    title: "Back",
                    onPressed: () {
                      Navigator.pop(context);
                    },
                  ),
                ],
              ),
            ),
          );
        },
      ),
    );
  }
}
